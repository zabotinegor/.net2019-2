using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.MoneyMovement.Delete.DeleteMoneyMovement
{
    public sealed class DeleteMoneyMovementQuery : IRequest<ResponseModel<object>>
    {
        public int MoneyMovementId { get; }

        public DeleteMoneyMovementQuery(int moneyMovementId)
        {
            MoneyMovementId = moneyMovementId;
        }
    }

    public class DeleteMoneyMovementHandler : BaseHandler, IRequestHandler<DeleteMoneyMovementQuery, ResponseModel<object>>
    {
        public async Task<ResponseModel<object>> Handle(DeleteMoneyMovementQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var moneyMovement = await uow.MoneyMovementRepository.Get(r => r.Id == request.MoneyMovementId)
                                    .FirstOrDefaultAsync(cancellationToken);

                if (moneyMovement == null)
                {
                    return GenerateNotFoundResult<object>(OperationType.Delete,
                            nameof(moneyMovement),
                            request.MoneyMovementId);
                }

                uow.MoneyMovementRepository.Remove(moneyMovement);

                try
                {
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return GenerateDatabaseErrorResult<object>(OperationType.Delete,
                            ex.Message);
                }
            }

            return GenerateSuccessResult<object>(OperationType.Delete);
        }
    }
}
