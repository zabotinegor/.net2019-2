using System;
using Task.CommonTypes.Interfaces;
using Task.CommonTypes.Models;
using Task.ConsoleApp.Enums;
using Task.ProcessingLogic;

namespace Task.ConsoleApp
{
    class Program
    {
        private static MenuState menuState = MenuState.EnterUser;
        private static IRepository<IUser> userRepositoryAggregator;

        static void Main(string[] args)
        {
            userRepositoryAggregator = new UserRepositoryAggregator<IUser>();

            Console.WriteLine(CommonTypes.Resources.Resources.HelloMessage);
            PressAnyKeyAndClear();

            bool showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu();
            }

            Console.Clear();
            Console.WriteLine(CommonTypes.Resources.Resources.GoodByeMessage);
            Console.Write(CommonTypes.Resources.Resources.KeyToContinueMessage);
            PressAnyKeyAndClear();
        }

        private static bool MainMenu()
        {
            bool result = true;

            switch (menuState)
            {
                case MenuState.EnterUser:
                    if (LogIn())
                    {
                        menuState = MenuState.EnterCommand;
                    }
                    else
                    {
                        Console.WriteLine(CommonTypes.Resources.Resources.UserNameError);
                        Console.Write(CommonTypes.Resources.Resources.KeyToContinueMessage);
                        PressAnyKeyAndClear();
                    }
                    break;
                case MenuState.EnterCommand:
                    result = ExecuteCommand();
                    break;
            }

            return result;
        }

        private static bool ExecuteCommand()
        {
            bool result = true;

            Console.Clear();
            Console.WriteLine(string.Concat("1. ", CommonTypes.Resources.Resources.ShowAllInvite));
            Console.WriteLine(string.Concat("2. ", CommonTypes.Resources.Resources.CreateIncomeInvite));
            Console.WriteLine(string.Concat("3. ", CommonTypes.Resources.Resources.CreateOutcomeInvite));
            Console.WriteLine(string.Concat("0. ", CommonTypes.Resources.Resources.ExitInvite));
            
            switch(ConvertToCommand(Console.ReadKey()))
            {
                case Command.ShowAll:
                    result = true;
                    break;
                case Command.NewIncome:
                    result = true;
                    break;
                case Command.NewOutcome:
                    result = true;
                    break;
                case Command.Exit:
                    result = false;
                    break;
            }

            return result;
        }

        private static Command ConvertToCommand(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return Command.ShowAll;
                case ConsoleKey.D2:
                    return Command.NewIncome;
                case ConsoleKey.D3:
                    return Command.NewOutcome;
                case ConsoleKey.D0:
                    return Command.Exit;
                default:
                    return Command.NoCommand;
            }
        }

        private static bool LogIn()
        {
            Console.WriteLine(CommonTypes.Resources.Resources.EnterUserMessage);
            Console.Write(CommonTypes.Resources.Resources.EnterUserFirstName);
            var firstName = Console.ReadLine();
            Console.Write(CommonTypes.Resources.Resources.EnterUserLastName);
            var lastName = Console.ReadLine();

            var result = userRepositoryAggregator.Add(new User()
            {
                FirstName = firstName,
                LastName = lastName
            });

            //TODO: Change
            return false;
            //return result;
        }

        private static void PressAnyKeyAndClear()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
