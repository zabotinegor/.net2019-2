using System;
using Task.CommonTypes.Enums;

namespace Task.CommonTypes.Interfaces
{
    public interface IMoneyMovement
    {
        int Id { get; set; }

        Direction Direction { get; set; }

        Currency Currency { get; set; }

        decimal Amount { get; set; }

        DateTime Date { get; set; }

        int UserId { get; set; }
    }
}