using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Class Character
    /// </summary>
    public class Character
    {
        // Creation of the new player
        public Player newPlayer = new Player(0, 0, 0, 0, 0, 0, "", "", 0, 0, 0, 0, 0, 0, 0); 

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


        string infoClassBanner = @"
█ █▄░█ █▀▀ █▀█   █▀▀ █░░ ▄▀█ █▀ █▀
█ █░▀█ █▀░ █▄█   █▄▄ █▄▄ █▀█ ▄█ ▄█";

        /// <summary>
        /// Character class constructor
        /// </summary>
        public Character()
        {
            CreateCharacter();
        }
        /// <summary>
        /// Creation of a new character with fixed stats for gold, xp and starting from level 1
        /// </summary>
        public void CreateCharacter()
        {
            newPlayer.Gold = 20.0f;
            newPlayer.ExperiencePoints = 0;
            newPlayer.Level = 1;
            InsertPlayerName();
            InsertPlayerRace();
            InsertPlayerClass();
        }

        /// <summary>
        /// The player choose the class with modifiers 
        /// </summary>
        /// <returns></returns>
        private bool InsertPlayerClass()
        {
            int playerClassInt = 0;
            bool insertLoop = true;

            while (insertLoop)
            {
                Console.Clear();
                Console.WriteLine(banner);
                Console.WriteLine();
                Console.WriteLine(characterCreationBanner);
                Console.WriteLine();
                Console.WriteLine("You have 4 available classes.");
                Console.WriteLine("Any of these classes can give you diffent difficult level.");
                Console.WriteLine("Chose a number in correspondence of the class that you like!");
                Console.WriteLine();
                Console.WriteLine("==============");
                Console.WriteLine("| 1) Warrior |");
                Console.WriteLine("| 2) Mage    |");
                Console.WriteLine("| 3) Paladin |");
                Console.WriteLine("| 4) Bard    |");
                Console.WriteLine("~~~~~~~~~~~~~~");
                Console.WriteLine("| 5) Info    |");
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
                                WarriorClassModifier();
                                insertLoop = false;   
                            }
                            break;

                        case 2:
                            playerClass = PlayerClass.Mage;
                            if (GetConfirmation(((PlayerClass)playerClassInt).ToString()))
                            {
                                newPlayer.playerClass = playerClass;
                                MageClassModifier();

                                insertLoop = false;  
                            }
                            break;

                        case 3:
                            playerClass = PlayerClass.Paladin;
                            if (GetConfirmation(((PlayerClass)playerClassInt).ToString()))
                            {
                                newPlayer.playerClass = playerClass;
                                PaladinClassModifier();
                                insertLoop = false;
                                
                            }
                            break;

                        case 4:
                            playerClass = PlayerClass.Bard;
                            if (GetConfirmation(((PlayerClass)playerClassInt).ToString()))
                            {
                                newPlayer.playerClass = playerClass;
                                BardClassModifier();
                                insertLoop = false;
                                
                            }
                            break;

                        case 5:
                            ShowInfoClasses();
 
                            break;

                        default:
                            Console.WriteLine("Invalid input! Try again!");
                            Console.WriteLine("Chose a class.");
                            Console.Write(":> ");

                            break;
                    }
                
            }

            return insertLoop;
        }

        /// <summary>
        /// Shows the info of each class that the player can choose
        /// </summary>
        private void ShowInfoClasses()
        {
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine(infoClassBanner);
            Console.WriteLine();
            Console.WriteLine("*** WARRIOR ***");
            Console.WriteLine();
            Console.WriteLine(" Attack: 0 - 3");
            Console.WriteLine(" Defense: 1 - 4" );
            Console.WriteLine(" HP: 20" );

            Console.WriteLine();
            Console.WriteLine("*** MAGE ***");
            Console.WriteLine();
            Console.WriteLine(" Attack: 0 - 3");
            Console.WriteLine(" Defense: 0 - 3");
            Console.WriteLine(" HP: 15");

            Console.WriteLine();
            Console.WriteLine("*** PALADIN ***");
            Console.WriteLine();
            Console.WriteLine(" Attack: 0 - 3");
            Console.WriteLine(" Defense: 1 - 4");
            Console.WriteLine(" HP: 20");

            Console.WriteLine();
            Console.WriteLine("*** BARD ***");
            Console.WriteLine();
            Console.WriteLine(" Attack: 0 - 3");
            Console.WriteLine(" Defense: 0 - 3");
            Console.WriteLine(" HP: 10");
            Console.WriteLine();
            Console.Write("[ENTER] to go back...");
            Console.ReadKey();
            
        }

        private void BardClassModifier()
        {
            newPlayer.CurrentHitPoints = 10;
            newPlayer.MaximumHitPoints = 10;
            newPlayer.ClassMinimumDamage = 0;
            newPlayer.ClassMaximumDamage = 1;
            newPlayer.ClassMinimumProtection = 0;
            newPlayer.ClassMaximumProtection = 2;
        }

        private void PaladinClassModifier()
        {
            newPlayer.CurrentHitPoints = 20;
            newPlayer.MaximumHitPoints = 20;
            newPlayer.ClassMinimumDamage = 0;
            newPlayer.ClassMaximumDamage = 2;
            newPlayer.ClassMinimumProtection = 1;
            newPlayer.ClassMaximumProtection = 3;
        }

        private void MageClassModifier()
        {
            newPlayer.CurrentHitPoints = 15;
            newPlayer.MaximumHitPoints = 15;
            newPlayer.ClassMinimumDamage = 0;
            newPlayer.ClassMaximumDamage = 2;
            newPlayer.ClassMinimumProtection = 0;
            newPlayer.ClassMaximumProtection = 2;
        }

        private void WarriorClassModifier()
        {
            newPlayer.CurrentHitPoints = 20;
            newPlayer.MaximumHitPoints = 20;
            newPlayer.ClassMinimumDamage = 0;
            newPlayer.ClassMaximumDamage = 2;
            newPlayer.ClassMinimumProtection = 1;
            newPlayer.ClassMaximumProtection = 3;
        }

        /// <summary>
        /// The player choose the Race
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// The player choose the name
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Confirmation method
        /// </summary>
        /// <param name="playerInput">The player input</param>
        /// <returns></returns>
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

        
    }
}
