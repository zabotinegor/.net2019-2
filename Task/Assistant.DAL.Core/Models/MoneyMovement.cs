using Assistant.Common.Enums;
using System;

namespace Assistant.DAL.Core.Models
{
    public class MoneyMovement
    {
        public int Id { get; set; }

        public Direction Direction { get; set; }

        public Currency Currency { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}
