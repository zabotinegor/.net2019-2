using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.MoneyMovement.Read.GetMoneyMovementById
{
    public sealed class GetMoneyMovementByIdQuery : IRequest<ResponseModel<MoneyMovementDto>>
    {
        public int MoneyMovementId { get; }

        public GetMoneyMovementByIdQuery(int moneyMovementId)
        {
            MoneyMovementId = moneyMovementId;
        }
    }

    public class GetMoneyMovementByIdHandler : BaseHandler, IRequestHandler<GetMoneyMovementByIdQuery, ResponseModel<MoneyMovementDto>>
    {
        public async Task<ResponseModel<MoneyMovementDto>> Handle(GetMoneyMovementByIdQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var moneyMovement = await uow.MoneyMovementRepository
                                 .Get(r => r.Id == request.MoneyMovementId)
                                 .FirstOrDefaultAsync(cancellationToken);

                return GenerateSuccessResult(OperationType.Get, moneyMovement?.ToMoneyMovementDto());
            }
        }
    }
}
