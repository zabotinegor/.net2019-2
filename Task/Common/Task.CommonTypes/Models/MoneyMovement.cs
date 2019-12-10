using System;
using Task.CommonTypes.Enums;
using Task.CommonTypes.Interfaces;

namespace Task.CommonTypes.Models
{
    public class MoneyMovement : IMoneyMovement
    {
        public int Id { get; set; }
        public Direction Direction { get; set; }
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}