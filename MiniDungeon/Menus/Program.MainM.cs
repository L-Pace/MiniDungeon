using System;


namespace MiniDungeon
{
    partial class Program
    {

        /// <summary>
        /// Main menu class
        /// </summary>
        public partial class MainM
        {
            /// <summary>
            /// Main Menu` contructor
            /// </summary>
            public MainM()
            {
                MainMenu();
            }
            #region menu1
            /// <summary>
            /// Main Menu` Method that shows some options for the player (Move somewhere, Explore, the inventory, Quest book and player stats)
            /// </summary>
            private static void MainMenu()
            {
                string playerInput;


                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(miniDungeonText);
                    Console.WriteLine();
                    Console.WriteLine("*** CURRENT LOCATION ***");
                    Console.WriteLine(" => " + _character.newPlayer.CurrentLocation.Name.ToString());
                    Console.WriteLine();
                    Console.WriteLine("*** DESCRIPTION ***");
                    Console.WriteLine("<-------------------------------------------------->");
                    Console.WriteLine(" " + _character.newPlayer.CurrentLocation.Description.ToString());
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
                        _ = new MoveM();
                    }
                    else if (playerInput == "e" || playerInput == "explore")
                    {
                        _ = new ExploreM();
                    }
                    else if (playerInput == "i" || playerInput == "inventory")
                    {
                        _ = new InventoryM();
                    }
                    else if (playerInput == "q" || playerInput == "quests" || playerInput == "quest")
                    {

                        if (_character.newPlayer.Quests.Count != 0)
                        {
                            ShowQuests();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(miniDungeonText);
                            Console.WriteLine(questBookText);
                            Console.WriteLine();
                            Console.WriteLine("Your Quest book is empty?!? You slacker!!");
                            Console.WriteLine();
                            Console.Write("[ENTER] to go back...");
                            Console.ReadKey();
                        }
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
                        // This menu` supposed to be the option menu` with the save system. 
                        //OptionsMenu();
                    }
                    else
                    {
                        InvalidInput();
                    }
                }



            }
            #endregion

            /// <summary>
            /// Show all the quest accepted and the status of them
            /// </summary>
            private static void ShowQuests()
            {
                Console.Clear();
                Console.WriteLine(miniDungeonText);
                Console.WriteLine(questBookText);
                Console.WriteLine();
                foreach (PlayerQuest pq in _character.newPlayer.Quests)
                {
                    Console.WriteLine("<====================================================================>");
                    Console.WriteLine("*** TITLE ***");
                    Console.WriteLine(pq.Details.Name);
                    Console.WriteLine();
                    Console.WriteLine("*** DESCRIPTION ***");
                    Console.WriteLine(pq.Details.Description);
                    Console.WriteLine();
                    Console.WriteLine("*** STATUS ***");
                    Console.WriteLine(" " + pq.IsCompleted.ToString());
                    Console.WriteLine("<====================================================================>");
                }
                Console.WriteLine();
                Console.Write("[ENTER] to go back...");
                Console.ReadKey();
            }

            
        }
    }
}
