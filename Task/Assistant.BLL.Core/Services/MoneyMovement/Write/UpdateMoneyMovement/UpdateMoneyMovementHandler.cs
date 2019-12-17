using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.MoneyMovement.Write.UpdateMoneyMovement
{
    public sealed class UpdateMoneyMovementQuery : IRequest<ResponseModel<MoneyMovementDto>>
    {
        public MoneyMovementDto MoneyMovementDto { get; }

        public UpdateMoneyMovementQuery(MoneyMovementDto moneyMovementDto)
        {
            MoneyMovementDto = moneyMovementDto;
        }
    }

    public class UpdateMoneyMovementHandler : BaseHandler, IRequestHandler<UpdateMoneyMovementQuery, ResponseModel<MoneyMovementDto>>
    {
        public async Task<ResponseModel<MoneyMovementDto>> Handle(UpdateMoneyMovementQuery request, CancellationToken cancellationToken)
        {
            using (var uow = UnitOfWork)
            {
                var moneyMovement = await uow.MoneyMovementRepository
                                 .Get(r => r.Id == request.MoneyMovementDto.Id)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(cancellationToken);

                if (moneyMovement == null)
                {
                    return GenerateNotFoundResult<MoneyMovementDto>(OperationType.Put,
                            nameof(moneyMovement),
                            request.MoneyMovementDto.Id);
                }

                moneyMovement = request.MoneyMovementDto
                              .CheckChangeableProps(moneyMovement)
                              .ToMoneyMovement();

                uow.MoneyMovementRepository.Update(moneyMovement);

                try
                {
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return GenerateDatabaseErrorResult<MoneyMovementDto>(OperationType.Put,
                            ex.Message);
                }

                return GenerateSuccessResult(OperationType.Put, moneyMovement.ToMoneyMovementDto());
            }
        }
    }
}
