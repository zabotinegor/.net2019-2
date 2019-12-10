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
        private static UserRepositoryAggregator<IUser> userRepositoryAggregator;
        private static MoneyMovementRepositoryAggregator<IMoneyMovement> moneyMovementRepositoryAggregator;

        static void Main(string[] args)
        {
            userRepositoryAggregator = new UserRepositoryAggregator<IUser>();
            moneyMovementRepositoryAggregator = new MoneyMovementRepositoryAggregator<IMoneyMovement>();

            Console.WriteLine(CommonTypes.Resources.Resources.HelloMessage);
            PressAnyKeyAndClear();

            bool showMenu = true;

            while(showMenu)
            {
                showMenu = MainMenu();
            }

            Console.ReadKey();
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
                        Console.WriteLine(CommonTypes.Resources.Resources.ErrorUserName);
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
            return false;
        }

        private static bool LogIn()
        {
            Console.WriteLine(CommonTypes.Resources.Resources.EnterUserMessage);
            Console.Write(CommonTypes.Resources.Resources.EnterUserFirstName);
            var firstName = Console.ReadLine();
            Console.Write(CommonTypes.Resources.Resources.EnterUserLastName);
            var lastName = Console.ReadLine();

            bool result = userRepositoryAggregator.CreateOrChoose( new User()
            {
                FirstName = firstName,
                LastName = lastName
            });

            return result;
        }

        private static void PressAnyKeyAndClear()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
