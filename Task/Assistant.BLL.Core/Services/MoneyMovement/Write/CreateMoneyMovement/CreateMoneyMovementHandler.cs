using Assistant.BLL.Core.Helpers;
using Assistant.BLL.Core.Infrastructure;
using Assistant.Common.Dto;
using Assistant.Common.Enums;
using Assistant.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.BLL.Core.Services.MoneyMovement.Write.CreateMoneyMovement
{
    public sealed class CreateMoneyMovementQuery : IRequest<ResponseModel<int>>
    {
        public MoneyMovementDto MoneyMovementDto { get; }

        public CreateMoneyMovementQuery(MoneyMovementDto moneyMovementDto)
        {
            MoneyMovementDto = moneyMovementDto;
        }
    }

    public class CreateMoneyMovementHandler : BaseHandler, IRequestHandler<CreateMoneyMovementQuery, ResponseModel<int>>
    {
        public async Task<ResponseModel<int>> Handle(CreateMoneyMovementQuery request, CancellationToken cancellationToken)
        {
            if (request.MoneyMovementDto == null)
            {
                return GenerateIsNullResult<int>(OperationType.Post,
                        nameof(request.MoneyMovementDto));
            }

            using (var uow = UnitOfWork)
            {
                var moneyMovement = request.MoneyMovementDto.ToMoneyMovement();

                uow.MoneyMovementRepository.Create(moneyMovement);

                try
                {
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return GenerateDatabaseErrorResult<int>(OperationType.Post,
                            ex.Message);
                }

                return GenerateSuccessResult(OperationType.Post, moneyMovement.Id);
            }
        }
    }
}
