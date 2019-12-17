using Assistant.Common.Dto;
using Assistant.DAL.Core.Models;

namespace Assistant.BLL.Core.Helpers
{
    public static class MoneyMovementHelper
    {
        public static MoneyMovement ToMoneyMovement(this MoneyMovementDto model)
        {
            return new MoneyMovement
            {
                Id = model.Id,
                Amount = model.Amount,
                Currency = model.Currency,
                Date = model.Date,
                Direction = model.Direction,
                UserId = model.UserId
            };
        }

        public static MoneyMovementDto ToMoneyMovementDto(this MoneyMovement model)
        {
            return new MoneyMovementDto
            {
                Id = model.Id,
                Amount = model.Amount,
                Currency = model.Currency,
                Date = model.Date,
                Direction = model.Direction,
                UserId = model.UserId
            };
        }
    }
}
