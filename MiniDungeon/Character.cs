using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    class Character
    {

        Player newPlayer = new Player(0, 20, 0.0F, 0, 1);

        PlayerRace playerRace;
        PlayerClass playerClass;
        string playerName;

        public Character()
        {
            CreateCharacter();
        }

        public void CreateCharacter()
        {

            int playerRaceInt = 0;
            int playerClassInt = 0;
            bool insertLoop = true;

            newPlayer.Gold = 20;
            newPlayer.ExperiencePoints = 0;
            newPlayer.Level = 1;


            while (insertLoop)
            {
                Console.WriteLine("Insert your name: ");
                Console.Write(":> ");
                playerName = Console.ReadLine();
                if (GetConfirmation(playerName))
                {
                    newPlayer.PlayerName = playerName.ToString() ;
                    insertLoop = false;
                }
            }


            insertLoop = true;
            Console.Clear();

            while (insertLoop)
            {
                Console.WriteLine("You have 4 available races. Chose a number in correspondence of the race that you like!");
                Console.WriteLine();
                Console.WriteLine("=============");
                Console.WriteLine("| 1) Human  |");
                Console.WriteLine("| 2) Elf    |");
                Console.WriteLine("| 3) Dwarf  |");
                Console.WriteLine("| 4) Orc    |");
                Console.WriteLine("=============");
                Console.WriteLine();
                Console.WriteLine("Chose a race.");
                Console.Write(":> ");
                while (!int.TryParse(Console.ReadLine(), out playerRaceInt))
                {
                    Console.WriteLine("Invalid input! Try again!");
                    Console.WriteLine("Chose a race.");
                    Console.Write(":> ");
                }
                switch (playerRaceInt)
                {
                    case 1:
                        playerRace = PlayerRace.Human;
                        if (GetConfirmation(((PlayerRace)playerRaceInt).ToString()))
                        {
                            newPlayer.playerRace = playerRace;
                            insertLoop = false;
                        }


                        break;

                    case 2:
                        playerRace = PlayerRace.Elf;
                        if (GetConfirmation(((PlayerRace)playerRaceInt).ToString()))
                        {
                            newPlayer.playerRace = playerRace;
                            insertLoop = false;
                        }

                        break;

                    case 3:
                        playerRace = PlayerRace.Dwarf;
                        if (GetConfirmation(((PlayerRace)playerRaceInt).ToString()))
                        {
                            newPlayer.playerRace = playerRace;
                            insertLoop = false;
                        }

                        break;

                    case 4:
                        playerRace = PlayerRace.Orc;
                        if (GetConfirmation(((PlayerRace)playerRaceInt).ToString()))
                        {
                            newPlayer.playerRace = playerRace;
                            insertLoop = false;
                        }

                        break;

                    default:
                        Console.Clear();

                        Console.WriteLine("Invalid input! Try again!");

                        break;
                }
            }


            insertLoop = true;

            while (insertLoop)
            {
                Console.Clear();
                Console.WriteLine("You have 4 available classes. Chose a number in correspondence of the class that you like!");
                Console.WriteLine();
                Console.WriteLine("==============");
                Console.WriteLine("| 1) Warrior |");
                Console.WriteLine("| 2) Mage    |");
                Console.WriteLine("| 3) Paladin |");
                Console.WriteLine("| 4) Bard    |");
                Console.WriteLine("==============");
                Console.WriteLine();
                Console.WriteLine("Chose a class.");
                Console.Write(":> ");
                while (!int.TryParse(Console.ReadLine(), out playerClassInt))
                {
                    Console.WriteLine("Invalid input! Try again!");
                    Console.Write(":> ");
                }

                switch (playerClassInt)
                {
                    case 1:
                        playerClass = PlayerClass.Warrior;
                        if (GetConfirmation(((PlayerClass)playerClassInt).ToString()))
                        {
                            newPlayer.playerClass = playerClass;
                            newPlayer.CurrentHitPoints = 20;
                            newPlayer.MaximumHitPoints = 20;                           
                            insertLoop = false;
                        }
                        break;

                    case 2:
                        playerClass = PlayerClass.Mage;
                        if (GetConfirmation(((PlayerClass)playerClassInt).ToString()))
                        {
                            newPlayer.playerClass = playerClass;
                            newPlayer.CurrentHitPoints = 10;
                            newPlayer.MaximumHitPoints = 10;

                            insertLoop = false;
                        }
                        break;

                    case 3:
                        playerClass = PlayerClass.Paladin;
                        if (GetConfirmation(((PlayerClass)playerClassInt).ToString()))
                        {
                            newPlayer.playerClass = playerClass;
                            newPlayer.CurrentHitPoints = 20;
                            newPlayer.MaximumHitPoints = 20;
                            insertLoop = false;
                        }
                        break;

                    case 4:
                        playerClass = PlayerClass.Bard;
                        if (GetConfirmation(((PlayerClass)playerClassInt).ToString()))
                        {
                            newPlayer.playerClass = playerClass;
                            newPlayer.CurrentHitPoints = 10;
                            newPlayer.MaximumHitPoints = 10;
                            insertLoop = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input! Try again!");
                        Console.Write(":> ");
                        insertLoop = false;
                        break;
                }
            }

            PrintCharacter();
        }



        private bool GetConfirmation(string playerInput)
        {
            string response;

            while (true)
            {
                Console.WriteLine("Is " + playerInput + " correct? y/n");
                Console.Write(":> ");
                response = Console.ReadLine().ToLower();

                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    Console.Clear();

                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        public void PrintCharacter()
        {
            Console.WriteLine("Your name is: " + newPlayer.PlayerName);
            Console.WriteLine("Your race is: " + newPlayer.playerRace.ToString());
            Console.WriteLine("Your class is: " + newPlayer.playerClass.ToString());
            Console.WriteLine("Your level is: " + newPlayer.Level);
            Console.WriteLine("Your starting HP are: " + newPlayer.CurrentHitPoints);
            Console.WriteLine("You have: " + newPlayer.Gold + " gold");
            Console.WriteLine("Your experience point are: " + newPlayer.ExperiencePoints);

        }
    }
}
