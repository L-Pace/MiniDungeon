using System;


namespace MiniDungeon
{
    class Program
    {

        private static Player _player = new Player(0, 0, 0, 0, 0);
        private static Character _character;

        

        private static string title1 = @"
▒█░░▒█ █▀▀ █░░ █▀▀ █▀▀█ █▀▄▀█ █▀▀ 　 ▀▀█▀▀ █▀▀█ 
▒█▒█▒█ █▀▀ █░░ █░░ █░░█ █░▀░█ █▀▀ 　 ░░█░░ █░░█ 
▒█▄▀▄█ ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀░░░▀ ▀▀▀ 　 ░░▀░░ ▀▀▀▀";
        private static string title2 = @"
███╗░░░███╗██╗███╗░░██╗██╗  ██████╗░██╗░░░██╗███╗░░██╗░██████╗░███████╗░█████╗░███╗░░██╗
████╗░████║██║████╗░██║██║  ██╔══██╗██║░░░██║████╗░██║██╔════╝░██╔════╝██╔══██╗████╗░██║
██╔████╔██║██║██╔██╗██║██║  ██║░░██║██║░░░██║██╔██╗██║██║░░██╗░█████╗░░██║░░██║██╔██╗██║
██║╚██╔╝██║██║██║╚████║██║  ██║░░██║██║░░░██║██║╚████║██║░░╚██╗██╔══╝░░██║░░██║██║╚████║
██║░╚═╝░██║██║██║░╚███║██║  ██████╔╝╚██████╔╝██║░╚███║╚██████╔╝███████╗╚█████╔╝██║░╚███║
╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚═╝  ╚═════╝░░╚═════╝░╚═╝░░╚══╝░╚═════╝░╚══════╝░╚════╝░╚═╝░░╚══╝";

        static void Main(string[] args)
        {


            bool mainLoop = true;
            int playerChoice = 0;

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

                        NewGame();

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

        private static void NewGame()
        {
            _character = new Character();

           

            Console.Clear();

            Console.WriteLine(title2);

            Intro();

            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

            MainMenu();

        }

        private static void MainMenu()
        {
            string playerInput;


            while (true)
            {
                Console.Clear();
                Console.WriteLine(title2);
                Console.WriteLine();
                Console.WriteLine("*** CURRENT LOCATION ***");
                Console.WriteLine(" => " + _player.CurrentLocation.Name.ToString());
                Console.WriteLine();
                Console.WriteLine("*** DESCRIPTION ***");
                Console.WriteLine("<-------------------------------------------------->");
                Console.WriteLine(" " + _player.CurrentLocation.Description.ToString());
                Console.WriteLine("<-------------------------------------------------->");
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("| (M)ove     | Show (P)layer |");
                Console.WriteLine("| (E)xplore  | (I)nventory   |");
                Console.WriteLine("| (S)how Map | (Q)ests       |");
                Console.WriteLine("==============================");
                Console.WriteLine("                 | (O)ptions |");
                Console.WriteLine();
                Console.Write(":> ");
                playerInput = Console.ReadLine().ToLower();


                if (playerInput == "m" || playerInput == "move")
                {
                    MoveMenu();
                }
                else if (playerInput == "e" || playerInput == "explore")
                {

                }
                else if (playerInput == "i" || playerInput == "inventory")
                {
                    //InventoryMenu();
                }
                else if (playerInput == "q" || playerInput == "quests" || playerInput == "quest")
                {
                    //ShowQuests();
                }

                else if (playerInput == "p" || playerInput == "player" || playerInput == "show player")
                {
                    ShowPlayer();
                }
                else if (playerInput == "s" || playerInput == "map" || playerInput == "show map")
                {
                    ShowMap();
                }
                else if (playerInput == "o" || playerInput == "options")
                {
                    //OptionsMenu();
                }
                else
                {
                    InvalidInput();
                }
            }
        }

        private static void MoveMenu()
        {
            string playerInput;
            bool moveMenuLoop = true;


            Console.Clear();

            while (moveMenuLoop)
            {
                Console.WriteLine(title2);
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

                MoveTo(playerInput, moveMenuLoop);
                moveMenuLoop = false;
            }
        }

        private static bool MoveTo(string playerInput, bool moveMenuLoop)
        {
            Location locationNorth = _player.CurrentLocation.LocationToNorth;
            Location locationSouth = _player.CurrentLocation.LocationToSouth;
            Location locationEast = _player.CurrentLocation.LocationToEast;
            Location locationWest = _player.CurrentLocation.LocationToWest;



            if (playerInput == "n" || playerInput == "north")
            {
                moveMenuLoop = ItemRequiredChecker(locationNorth, moveMenuLoop);
            }
            else if (playerInput == "s" || playerInput == "south")
            {
                moveMenuLoop = ItemRequiredChecker(locationSouth, moveMenuLoop);

            }
            else if (playerInput == "e" || playerInput == "east")
            {
                moveMenuLoop = ItemRequiredChecker(locationEast, moveMenuLoop);

            }
            else if (playerInput == "w" || playerInput == "west")
            {
                moveMenuLoop = ItemRequiredChecker(locationWest, moveMenuLoop);
            }
            else if (playerInput == "b" || playerInput == "back")
            {
                Console.Clear();
            }
            else
            {
                InvalidInput();
            }
            return moveMenuLoop;
        }
        private static void ShowPlayer()
        {
            Console.Clear();
            Console.WriteLine(title2);
            _character.PrintCharacter();
            Console.WriteLine();
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }
        private static void ShowMap()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(title2);
            Console.WriteLine("==================================");
            Console.WriteLine("                MAP               ");
            ShowAvailableLocations(_player.CurrentLocation);
            Console.WriteLine("==================================");
            Console.WriteLine("");
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }


        private static void InvalidInput()
        {
            Console.Clear();
            Console.WriteLine(title2);
            Console.WriteLine("Invalid Input! Try again!");
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }


        private static bool ItemRequiredChecker(Location newLocation, bool moveMenuLoop)
        {
            if (newLocation != null)
            {
                if (newLocation.ItemRequiredToEnter != null)
                {
                    bool playerHasItemToEnter = false;
                    foreach (InventoryItem ii in _player.Inventory)
                    {
                        if (ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
                        {
                            playerHasItemToEnter = true;

                            break;
                        }
                    }
                    if (!playerHasItemToEnter)
                    {
                        Console.Clear();
                        Console.WriteLine(title2);
                        Console.WriteLine();
                        Console.WriteLine("You must have " + newLocation.ItemRequiredToEnter.Name + " to enter here!");
                        Console.WriteLine("[ENTER] to go back");
                        Console.ReadKey();
                        Console.Clear();
                        return false;

                    }
                    Console.Clear();
                }
                _player.CurrentLocation = newLocation;
            }
            else
            {
                WrongPathMessage();
            }

            return moveMenuLoop;
        }

        private static void WrongPathMessage()
        {
            Console.Clear();
            Console.WriteLine(title2);
            Console.WriteLine("You Can't go there");
            Console.WriteLine("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
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
