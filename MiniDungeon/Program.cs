using System;

namespace MiniDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mainLoop = true;
            int playerChoice = 0;


            Console.WriteLine("Welcome to the Mini Dungeon!!!");
            Console.WriteLine("");
            Console.WriteLine("==================");
            Console.WriteLine("| 1) New Game    |");
            Console.WriteLine("| 2) Credits     |");
            Console.WriteLine("| 3) Quit Game   |");
            Console.WriteLine("==================");
            Console.WriteLine("");

            Console.Write(":> ");

            while (mainLoop)
            {
                while (!int.TryParse(Console.ReadLine(), out playerChoice))
                {

                    Console.WriteLine("Invalid choice! Try again!");
                    Console.WriteLine(":> ");

                }
                switch (playerChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("   ********************");
                        Console.WriteLine("    CHARACTER CREATION");
                        Console.WriteLine("   ********************");
                        Console.WriteLine("");
                        Character character = new Character();
                        Location location = new Location(1, "Home", "This is your home!", null, null, null);
                        Console.WriteLine("Location: " + location.Name);
                        Console.WriteLine("Description: " + location.Description);
                        break;

                    case 2:

                        Console.WriteLine("Not implemented yet!");
                        Console.WriteLine("");
                        Console.WriteLine("==================");
                        Console.WriteLine("| 1) New Game    |");
                        Console.WriteLine("| 2) Credits     |");
                        Console.WriteLine("| 3) Quit Game   |");
                        Console.WriteLine("==================");
                        Console.WriteLine("");
                        Console.Write(":> ");
                        break;

                    case 3:

                        Console.WriteLine("Thank you for playing this small game! Hope that you enjoyed it!");
                        mainLoop = false;
                        break;

                    default:

                        break;
                }
            }


        }
    }
}
