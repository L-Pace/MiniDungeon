using System;


namespace MiniDungeon
{
    partial class Program
    {
        public partial class MainM
        {

            public MainM()
            {
                MainMenu();
            }
            #region menu1
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
                        //OptionsMenu();
                    }
                    else
                    {
                        InvalidInput();
                    }
                }



            }
            #endregion


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
