using System;

namespace Task.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Task.CommonTypes.Resources.Resources.HelloMessage);
            Console.ReadKey();

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
            int state = 0;

            return result;
        }
    }
}
