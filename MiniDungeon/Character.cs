using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    class Character
    {

        public Player newPlayer = new Player(0, 0, 0, 0, 0);
        private Weapon _weapon = new Weapon(0,"","",0,0,3);
        private Armor _armor = new Armor(0,"","",0,0,3); 

        PlayerRace playerRace;
        PlayerClass playerClass;
        string playerName;

        string banner = @"
███╗░░░███╗██╗███╗░░██╗██╗  ██████╗░██╗░░░██╗███╗░░██╗░██████╗░███████╗░█████╗░███╗░░██╗
████╗░████║██║████╗░██║██║  ██╔══██╗██║░░░██║████╗░██║██╔════╝░██╔════╝██╔══██╗████╗░██║
██╔████╔██║██║██╔██╗██║██║  ██║░░██║██║░░░██║██╔██╗██║██║░░██╗░█████╗░░██║░░██║██╔██╗██║
██║╚██╔╝██║██║██║╚████║██║  ██║░░██║██║░░░██║██║╚████║██║░░╚██╗██╔══╝░░██║░░██║██║╚████║
██║░╚═╝░██║██║██║░╚███║██║  ██████╔╝╚██████╔╝██║░╚███║╚██████╔╝███████╗╚█████╔╝██║░╚███║
╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚═╝  ╚═════╝░░╚═════╝░╚═╝░░╚══╝░╚═════╝░╚══════╝░╚════╝░╚═╝░░╚══╝";

        string characterCreationBanner = @"
█▀▀ █░█ ▄▀█ █▀█ ▄▀█ █▀▀ ▀█▀ █▀▀ █▀█   █▀▀ █▀█ █▀▀ ▄▀█ ▀█▀ █ █▀█ █▄░█
█▄▄ █▀█ █▀█ █▀▄ █▀█ █▄▄ ░█░ ██▄ █▀▄   █▄▄ █▀▄ ██▄ █▀█ ░█░ █ █▄█ █░▀█";
        public Character()
        {
            CreateCharacter();
        }

        public void CreateCharacter()
        {
            newPlayer.Gold = 20.0f;
            newPlayer.ExperiencePoints = 0;
            newPlayer.Level = 1;
            InsertPlayerName();
            InsertPlayerRace();
            InsertPlayerClass();
        }

        private int InsertPlayerClass()
        {
            int playerClassInt = 0;
            bool insertLoop = true;

            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine();
            Console.WriteLine(characterCreationBanner);
            Console.WriteLine();
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
            while (insertLoop)
            {
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
                        Console.WriteLine("Chose a class.");
                        Console.Write(":> ");

                        break;
                }
            }

            return playerClassInt;
        }

        private bool InsertPlayerRace()
        {
            int playerRaceInt = 0;

            bool insertLoop = true;
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine();
            Console.WriteLine(characterCreationBanner);
            Console.WriteLine();
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
            while (insertLoop)
            {
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

                        Console.WriteLine("Invalid input! Try again!");
                        Console.WriteLine("Chose a race");
                        Console.Write(":> ");
                        break;
                }
            }

            return insertLoop;
        }

        private bool InsertPlayerName()
        {
            bool insertLoop = true;
            while (insertLoop)
            {
                Console.Clear();
                Console.WriteLine(banner);
                Console.WriteLine();
                Console.WriteLine(characterCreationBanner);
                Console.WriteLine();

                Console.WriteLine("Insert your name: ");
                Console.Write(":> ");
                playerName = Console.ReadLine();
                if (GetConfirmation(playerName))
                {
                    newPlayer.PlayerName = playerName.ToString();
                    insertLoop = false;
                }
            }

            return insertLoop;
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
                    Console.WriteLine("Insert the correct one");
                    Console.Write(":> ");

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
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(" Name: " + newPlayer.PlayerName);
            Console.WriteLine(" Race: " + newPlayer.playerRace.ToString());
            Console.WriteLine(" Class: " + newPlayer.playerClass.ToString());
            Console.WriteLine(" Level: " + newPlayer.Level);
            Console.WriteLine(" Attack: " + _weapon.MinimumDamage + " - " + _weapon.MaximumDamage);
            Console.WriteLine(" Defense: " + _armor.MinimumProtection + " - " + _armor.MaximumProtection);
            Console.WriteLine(" HP: " + newPlayer.CurrentHitPoints);
            Console.WriteLine(" Money: " + newPlayer.Gold + " gold");
            Console.WriteLine(" XP: " + newPlayer.ExperiencePoints);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~");


        }
    }
}
