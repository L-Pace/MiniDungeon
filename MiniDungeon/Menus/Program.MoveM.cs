using System;


namespace MiniDungeon
{
    partial class Program
    {
        public class MoveM
        {
            public MoveM()
            {
                MoveMenu();
            }
            private static void MoveMenu()
            {
                string playerInput;
                bool moveMenuLoop = true;


                Console.Clear();

                while (moveMenuLoop)
                {
                    Console.WriteLine(miniDungeonText);
                    Console.WriteLine();
                    Console.WriteLine("*** CURRENT LOCATION ***");
                    Console.WriteLine(" => " + _character.newPlayer.CurrentLocation.Name.ToString());
                    Console.WriteLine();
                    Console.WriteLine("==================================");
                    Console.WriteLine("               MAP                ");
                    ShowAvailableLocations(_character.newPlayer.CurrentLocation);
                    Console.WriteLine("==================================");
                    Console.WriteLine();
                    Console.WriteLine("===============================");
                    Console.WriteLine("| Move (N)orth | Move (S)outh |");
                    Console.WriteLine("| Move (E)ast  | Move (W)est  |");
                    Console.WriteLine("===============================");
                    Console.WriteLine("| (B)ack |                         ");
                    Console.WriteLine();
                    Console.Write(":> ");
                    playerInput = Console.ReadLine();

                    MoveTo(playerInput, moveMenuLoop);
                    moveMenuLoop = false;
                }
            }

            private static bool MoveTo(string playerInput, bool moveMenuLoop)
            {
                Location locationNorth = _character.newPlayer.CurrentLocation.LocationToNorth;
                Location locationSouth = _character.newPlayer.CurrentLocation.LocationToSouth;
                Location locationEast = _character.newPlayer.CurrentLocation.LocationToEast;
                Location locationWest = _character.newPlayer.CurrentLocation.LocationToWest;



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
  

            private static bool ItemRequiredChecker(Location newLocation, bool moveMenuLoop)
            {
                if (newLocation != null)
                {
                    if (newLocation.ItemRequiredToEnter != null)
                    {
                        bool playerHasItemToEnter = false;
                        foreach (InventoryItem ii in _character.newPlayer.Inventory)
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
                            Console.WriteLine(miniDungeonText);
                            Console.WriteLine();
                            Console.WriteLine("You must have " + newLocation.ItemRequiredToEnter.Name + " to enter here!");
                            Console.WriteLine("[ENTER] to go back");
                            Console.ReadKey();
                            Console.Clear();
                            return false;

                        }
                        Console.Clear();
                    }
                    _character.newPlayer.CurrentLocation = newLocation;

                    _character.newPlayer.CurrentHitPoints = _character.newPlayer.MaximumHitPoints;
                }
                else
                {
                    WrongPathMessage();
                }

                return moveMenuLoop;
            }
        }
    }
}
