using System;

namespace MiniDungeon
{
    class Program
    {
        static void Main(string[] args)
        {

            bool mainLoop = true;
            int playerChoice = 0;
            string title1 = @"
▒█░░▒█ █▀▀ █░░ █▀▀ █▀▀█ █▀▄▀█ █▀▀ 　 ▀▀█▀▀ █▀▀█ 
▒█▒█▒█ █▀▀ █░░ █░░ █░░█ █░▀░█ █▀▀ 　 ░░█░░ █░░█ 
▒█▄▀▄█ ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀░░░▀ ▀▀▀ 　 ░░▀░░ ▀▀▀▀";

            string title2 = @"
███╗░░░███╗██╗███╗░░██╗██╗  ██████╗░██╗░░░██╗███╗░░██╗░██████╗░███████╗░█████╗░███╗░░██╗
████╗░████║██║████╗░██║██║  ██╔══██╗██║░░░██║████╗░██║██╔════╝░██╔════╝██╔══██╗████╗░██║
██╔████╔██║██║██╔██╗██║██║  ██║░░██║██║░░░██║██╔██╗██║██║░░██╗░█████╗░░██║░░██║██╔██╗██║
██║╚██╔╝██║██║██║╚████║██║  ██║░░██║██║░░░██║██║╚████║██║░░╚██╗██╔══╝░░██║░░██║██║╚████║
██║░╚═╝░██║██║██║░╚███║██║  ██████╔╝╚██████╔╝██║░╚███║╚██████╔╝███████╗╚█████╔╝██║░╚███║
╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚═╝  ╚═════╝░░╚═════╝░╚═╝░░╚══╝░╚═════╝░╚══════╝░╚════╝░╚═╝░░╚══╝";






            Console.WriteLine(title1);
            Console.WriteLine(title2);
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

                        Player _player = new Player(0, 0, 0, 0, 0);

                        NewGame(title2, _player);

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

        private static void NewGame(string banner, Player _player)
        {
            Character character = new Character();

            Console.Clear();

            Console.WriteLine(banner);

            //Intro();

            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

            MainMenu(_player, banner, character);

        }

        private static void MainMenu(Player _player, string banner, Character character)
        {
            string playerInput;

            while (true)
            {

                Console.WriteLine(banner);
                Console.WriteLine();
                Console.WriteLine("*** CURRENT LOCATION ***");
                Console.WriteLine(" => " + _player.CurrentLocation.Name.ToString());
                Console.WriteLine();
                Console.WriteLine("*** DESCRIPTION ***");
                Console.WriteLine("<-------------------------------------------------->");
                Console.WriteLine(" " + _player.CurrentLocation.Description.ToString());
                Console.WriteLine("<-------------------------------------------------->");
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine("| (M)ove            Show (P)layer |");
                Console.WriteLine("| (S)how Map        (I)nventory   |");
                Console.WriteLine("| (Q)ests           (O)ptions     |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.Write(":> ");
                playerInput = Console.ReadLine().ToLower();


                if (playerInput == "m" || playerInput == "move")
                {
                    MoveMenu(_player, banner);
                }
                else if (playerInput == "p" || playerInput == "show" || playerInput == "player" || playerInput == "show player")
                {
                    ShowPlayer(banner, character);
                }
                else if (playerInput == "s" || playerInput == "map" || playerInput == "show map")
                {
                    ShowMap(_player, banner);
                }
                else
                {
                    InvalidInput(banner);
                }
            }
        }

        private static void ShowMap(Player _player, string banner)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(banner);
            Console.WriteLine("==================================");
            Console.WriteLine("                MAP               ");
            ShowAvailableLocations(_player.CurrentLocation);
            Console.WriteLine("==================================");
            Console.WriteLine("");
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ShowPlayer(string banner, Character character)
        {
            Console.Clear();
            Console.WriteLine(banner);
            character.PrintCharacter();
            Console.WriteLine();
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        private static void MoveMenu(Player _player, string banner)
        {
            string playerInput;
            bool moveMenuLoop = true;


            Console.Clear();

            while (moveMenuLoop)
            {
                Console.WriteLine(banner);
                Console.WriteLine();
                Console.WriteLine("*** CURRENT LOCATION ***");
                Console.WriteLine(" => " + _player.CurrentLocation.Name.ToString());
                Console.WriteLine();
                Console.WriteLine("==================================");
                Console.WriteLine("               MAP                ");
                ShowAvailableLocations(_player.CurrentLocation);
                Console.WriteLine("==================================");
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine("| Move (N)orth       Move (S)outh |");
                Console.WriteLine("| Move (E)ast        Move (W)est  |");
                Console.WriteLine("| (B)ack                          |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.Write(":> ");
                playerInput = Console.ReadLine();


                if (playerInput == "n" || playerInput == "north")
                {

                    if (_player.CurrentLocation.LocationToNorth != null)
                    {
                        _player.CurrentLocation = _player.CurrentLocation.LocationToNorth;
                        MoveToNorth(_player.CurrentLocation.LocationToNorth, _player);
                        moveMenuLoop = false;
                        Console.Clear();
                    }
                    else
                    {
                        WrongPathMessage(banner);
                    }

                }
                else if (playerInput == "s" || playerInput == "south")
                {

                    if (_player.CurrentLocation.LocationToSouth != null)
                    {
                        _player.CurrentLocation = _player.CurrentLocation.LocationToSouth;
                        MoveToSouth(_player.CurrentLocation.LocationToSouth, _player);
                        moveMenuLoop = false;
                        Console.Clear();
                    }
                    else
                    {
                        WrongPathMessage(banner);
                    }
                }
                else if (playerInput == "e" || playerInput == "east")
                {

                    if (_player.CurrentLocation.LocationToEast != null)
                    {
                        _player.CurrentLocation = _player.CurrentLocation.LocationToEast;
                        MoveToEast(_player.CurrentLocation.LocationToEast, _player);
                        moveMenuLoop = false;
                        Console.Clear();
                    }
                    else
                    {
                        WrongPathMessage(banner);
                    }
                }
                else if (playerInput == "w" || playerInput == "west")
                {
                    if (_player.CurrentLocation.LocationToWest != null)
                    {
                        _player.CurrentLocation = _player.CurrentLocation.LocationToWest;
                        MoveToWest(_player.CurrentLocation.LocationToWest, _player);
                        Console.Clear();
                        moveMenuLoop = false;
                    }
                    else
                    {
                        WrongPathMessage(banner);
                    }
                }
                else if (playerInput == "b" || playerInput == "back")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    InvalidInput(banner);
                }
            }
        }

        private static void InvalidInput(string banner)
        {
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine("Invalid Input! Try again!");
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        private static void WrongPathMessage(string banner)
        {
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine("You Can't go there");
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        private static void MoveToWest(Location newLocation, Player _player)
        {
            _player.CurrentLocation.LocationToWest = newLocation;
        }


        private static void MoveToEast(Location newLocation, Player _player)
        {

            _player.CurrentLocation.LocationToEast = newLocation;

        }

        private static void MoveToSouth(Location newLocation, Player _player)
        {

            _player.CurrentLocation.LocationToSouth = newLocation;
        }

        private static void MoveToNorth(Location newLocation, Player _player)
        {

            _player.CurrentLocation.LocationToNorth = newLocation;

        }


        private static void ShowAvailableLocations(Location currentLocation)
        {
            if (currentLocation.LocationToNorth != null)
            {
                Console.WriteLine("North Location: " + currentLocation.LocationToNorth.Name.ToString());
            }
            else
            {
                Console.WriteLine("North Location: Nothing here");
            }

            if (currentLocation.LocationToSouth != null)
            {
                Console.WriteLine("South Location: " + currentLocation.LocationToSouth.Name.ToString());
            }
            else
            {
                Console.WriteLine("South Location: Nothing here");
            }

            if (currentLocation.LocationToEast != null)
            {
                Console.WriteLine("East Location: " + currentLocation.LocationToEast.Name.ToString());
            }
            else
            {
                Console.WriteLine("East Location: Nothing here");
            }

            if (currentLocation.LocationToWest != null)
            {
                Console.WriteLine("West Location: " + currentLocation.LocationToWest.Name.ToString());
            }
            else
            {
                Console.WriteLine("West Location: Nothing here");
            }
        }

        private static void Intro()
        {
            Console.WriteLine();

            Console.WriteLine("Narrator: A long time ago Compass house was an happy Town where people came just ");
            Console.WriteLine("          to spend their holidays and enjoy their life out of the busy life in Cambridge City.");
            Console.ReadKey();
            Console.WriteLine("Narrator: Our Mini Dungeon, made by our Ancient Lords, was attracting also a lot of people.");
            Console.ReadKey();
            Console.WriteLine("Narrator: You could explore the darkest parts of the dungeon without being bothered to any creature.");
            Console.ReadKey();
            Console.WriteLine("Narrator: Yes, we used for centuries the Mini dungeon as a Museum.");
            Console.ReadKey();
            Console.WriteLine("Narrator: We were rich and we were living the best of our life with everybody.");
            Console.ReadKey();
            Console.WriteLine("Narrator: One day a Lord, Viktor One Foot, from The Red Castle, came in Compass House ");
            Console.WriteLine("          with his guards: Oliver The Chosen One and Luke The Gentle Giant.");
            Console.ReadKey();
            Console.WriteLine("Narrator: They were really friendly and they offered improvment for our Mini Dungeon with amazing technologies.");
            Console.ReadKey();
            Console.WriteLine("Narrator: They were talking about blueprints, textures and a graphic engine that supposed ");
            Console.WriteLine("          to increase the income of our small town.");
            Console.ReadKey();
            Console.WriteLine("Narrator: I have no idea what they were talking about, to be honest.");
            Console.ReadKey();
            Console.WriteLine("Narrator: We were desperate because Cambridge Town was taking over all the land ");
            Console.WriteLine("          that sorrounded us and we needed help.");
            Console.ReadKey();
            Console.WriteLine("Narrator: What a mistake. We trusted them and we gave them the Mini Dungeon for refrubishment.");
            Console.ReadKey();
            Console.WriteLine("Narrator: Yes, they refrubished but they call their troupes for help: a bunch of ");
            Console.WriteLine("          goblin and troll that now infesting the forest and the Ancient Lake.....");
            Console.ReadKey();
            Console.WriteLine("Narrator: Ah wait, Viktor changed even the name of our sacred places.");
            Console.WriteLine("          It was Ancient Lake now is called Red Lake.");
            Console.ReadKey();
            Console.WriteLine("Narrator: Now Viktor is sitting on the throne inside of the Mini Dungeon.");
            Console.ReadKey();
            Console.WriteLine("Narrator: Some rumors saying that he's locked inside, eating and playing a game: someone said that is called New World ");
            Console.WriteLine("          other people talking about Dyson Sphere Program! What the heck is going on in the Mini Dungeon?");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
