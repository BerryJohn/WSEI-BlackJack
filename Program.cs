using System;


namespace wsei_blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 1;

            while (true)
            {
                Menu(menuChoice);
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (menuChoice >= 2)
                        menuChoice -= 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (menuChoice <= 1)
                        menuChoice += 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    switch (menuChoice)
                    {
                        case 1:
                            Game blackjack = new Game();
                            break;
                        case 2:
                            return;
                        default:
                            return;
                    }
                }

            }
        }

        static void Menu(int choice)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Blackjack!");
            switch (choice)
            {
                case 1:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("1.Start game");
                    Console.ResetColor();
                    Console.WriteLine("2.Quit");
                    break;
                case 2:
                    Console.WriteLine("1.Start game");
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("2.Quit");
                    Console.ResetColor();
                    break;
                default:
                    break;
            }
        }
    }
}

