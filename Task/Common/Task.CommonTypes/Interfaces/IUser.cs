﻿namespace Task.CommonTypes.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}