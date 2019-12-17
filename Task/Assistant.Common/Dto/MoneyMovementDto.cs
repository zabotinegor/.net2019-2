using Assistant.Common.Enums;
using System;

namespace Assistant.Common.Dto
{
    public class MoneyMovementDto
    {
        public int Id { get; set; }

        public Direction Direction { get; set; }

        public Currency Currency { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}
