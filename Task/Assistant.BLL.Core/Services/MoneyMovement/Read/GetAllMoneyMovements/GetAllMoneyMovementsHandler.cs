using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.MoneyMovement.Read.GetAllMoneyMovements
{
    public sealed class GetAllMoneyMovementsQuery : IRequest<ResponseModel<IEnumerable<MoneyMovementDto>>>
    {

    }

    public class GetAllMoneyMovementsHandler : BaseHandler, IRequestHandler<GetAllMoneyMovementsQuery, ResponseModel<IEnumerable<MoneyMovementDto>>>
    {
        public async Task<ResponseModel<IEnumerable<MoneyMovementDto>>> Handle(GetAllMoneyMovementsQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var result = await uow.MoneyMovementRepository.Get().ToListAsync(cancellationToken);

                return GenerateSuccessResult(OperationType.Get, result?.Select(r => r.ToMoneyMovementDto()));
            }
        }
    }
}
