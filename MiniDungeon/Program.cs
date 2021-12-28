using System;

namespace MiniDungeon
{
    class Program
    {
        private Monster _monster;
        private Player _player;

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

                        Player _player = new Player(0,0,0,0,0);

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

            Intro();

            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);

            MainMenu(_player.CurrentLocation, _player, banner, character);

        }

        private static void MainMenu(Location newLocation, Player _player, string banner, Character character)
        {
            string playerInput;


            while (true)
            {
                Console.WriteLine(banner);
                character.PrintCharacter();

                Console.WriteLine();
                Console.WriteLine("Current Location: " + newLocation.Name.ToString());
                Console.WriteLine("\n");
                Console.WriteLine("===================================");
                Console.WriteLine("| Move (N)orth       Move (S)outh |");
                Console.WriteLine("| Move (E)ast        Move (W)est  |");
                Console.WriteLine("| (L)ocation info    (M)ap        |");
                Console.WriteLine("===================================");
                Console.Write(":> ");
                playerInput = Console.ReadLine().ToLower();

                if (playerInput == "n" || playerInput == "north")
                {
                    MoveNorth(newLocation);
                }
                else if (playerInput == "s" || playerInput == "south")
                {
                    //MoveSouth
                }
                else if (playerInput == "e" || playerInput == "east")
                {
                    //MoveEast
                }
                else if (playerInput == "w" || playerInput == "west")
                {
                    //MoveWest
                }
                else if (playerInput == "l" || playerInput == "location" || playerInput == "info" || playerInput == "location info")
                {
                    Console.WriteLine(newLocation.Description.ToString());
                }
                else if (playerInput == "m" || playerInput == "map")
                {
                    Console.WriteLine();

                    Console.WriteLine("=======================");
                    Console.WriteLine("          MAP          ");
                    ShowAvailableLocations(_player.CurrentLocation);
                    Console.WriteLine("=======================");
                } 
            }
        }

        private static void MoveNorth(Location newLocation)
        {
            throw new NotImplementedException();
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

        //public static void MoveTo(Location location)
        //{
        //    Player _player;

        //    _player.CurrentLocation = location;

        //    Console.WriteLine(location.ToString());


        //}

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
