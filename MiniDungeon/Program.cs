using System;
using System.Collections.Generic;


namespace MiniDungeon
{
    partial class Program
    {

        private static Character _character;
        private static Monster _currentMonster;
        private static List<Weapon> _weapons;
        private static List<Armor> _armors;
        private static List<HealingPotion> _healingPotions;


        private static string welcomeText = @"
▒█░░▒█ █▀▀ █░░ █▀▀ █▀▀█ █▀▄▀█ █▀▀ 　 ▀▀█▀▀ █▀▀█ 
▒█▒█▒█ █▀▀ █░░ █░░ █░░█ █░▀░█ █▀▀ 　 ░░█░░ █░░█ 
▒█▄▀▄█ ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀░░░▀ ▀▀▀ 　 ░░▀░░ ▀▀▀▀";
        private static string miniDungeonText = @"
███╗░░░███╗██╗███╗░░██╗██╗  ██████╗░██╗░░░██╗███╗░░██╗░██████╗░███████╗░█████╗░███╗░░██╗
████╗░████║██║████╗░██║██║  ██╔══██╗██║░░░██║████╗░██║██╔════╝░██╔════╝██╔══██╗████╗░██║
██╔████╔██║██║██╔██╗██║██║  ██║░░██║██║░░░██║██╔██╗██║██║░░██╗░█████╗░░██║░░██║██╔██╗██║
██║╚██╔╝██║██║██║╚████║██║  ██║░░██║██║░░░██║██║╚████║██║░░╚██╗██╔══╝░░██║░░██║██║╚████║
██║░╚═╝░██║██║██║░╚███║██║  ██████╔╝╚██████╔╝██║░╚███║╚██████╔╝███████╗╚█████╔╝██║░╚███║
╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚═╝  ╚═════╝░░╚═════╝░╚═╝░░╚══╝░╚═════╝░╚══════╝░╚════╝░╚═╝░░╚══╝";

        private static string fightText = @"
███████████████▀███████████
█▄─▄▄─█▄─▄█─▄▄▄▄█─█─█─▄─▄─█
██─▄████─██─██▄─█─▄─███─███
▀▄▄▄▀▀▀▄▄▄▀▄▄▄▄▄▀▄▀▄▀▀▄▄▄▀▀";

        private static string victoryText = @"
██╗░░░██╗██╗░█████╗░████████╗░█████╗░██████╗░██╗░░░██╗
██║░░░██║██║██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗╚██╗░██╔╝
╚██╗░██╔╝██║██║░░╚═╝░░░██║░░░██║░░██║██████╔╝░╚████╔╝░
░╚████╔╝░██║██║░░██╗░░░██║░░░██║░░██║██╔══██╗░░╚██╔╝░░
░░╚██╔╝░░██║╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║░░░██║░░░
░░░╚═╝░░░╚═╝░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝░░░╚═╝░░░";

        private static string deadText = @"        
██╗░░░██╗░█████╗░██╗░░░██╗  ░█████╗░██████╗░███████╗  ██████╗░███████╗░█████╗░██████╗░
╚██╗░██╔╝██╔══██╗██║░░░██║  ██╔══██╗██╔══██╗██╔════╝  ██╔══██╗██╔════╝██╔══██╗██╔══██╗
░╚████╔╝░██║░░██║██║░░░██║  ███████║██████╔╝█████╗░░  ██║░░██║█████╗░░███████║██║░░██║
░░╚██╔╝░░██║░░██║██║░░░██║  ██╔══██║██╔══██╗██╔══╝░░  ██║░░██║██╔══╝░░██╔══██║██║░░██║
░░░██║░░░╚█████╔╝╚██████╔╝  ██║░░██║██║░░██║███████╗  ██████╔╝███████╗██║░░██║██████╔╝
░░░╚═╝░░░░╚════╝░░╚═════╝░  ╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝  ╚═════╝░╚══════╝╚═╝░░╚═╝╚═════╝░";


        private static string questBookText = @"
█▀█ █░█ █▀▀ █▀ ▀█▀   █▄▄ █▀█ █▀█ █▄▀
▀▀█ █▄█ ██▄ ▄█ ░█░   █▄█ █▄█ █▄█ █░█";

        private static string inventoryText = @"
█ █▄░█ █░█ █▀▀ ▀█▀ █▀█ █▀█ █▄█
█ █░▀█ ▀▄▀ ██▄ ░█░ █▄█ █▀▄ ░█░";


        private static string gameOverText = @"████████╗██╗░░██╗░█████╗░███╗░░██╗██╗░░██╗  ██╗░░░██╗░█████╗░██╗░░░██╗  ███████╗░█████╗░██████╗░
╚══██╔══╝██║░░██║██╔══██╗████╗░██║██║░██╔╝  ╚██╗░██╔╝██╔══██╗██║░░░██║  ██╔════╝██╔══██╗██╔══██╗
░░░██║░░░███████║███████║██╔██╗██║█████═╝░  ░╚████╔╝░██║░░██║██║░░░██║  █████╗░░██║░░██║██████╔╝
░░░██║░░░██╔══██║██╔══██║██║╚████║██╔═██╗░  ░░╚██╔╝░░██║░░██║██║░░░██║  ██╔══╝░░██║░░██║██╔══██╗
░░░██║░░░██║░░██║██║░░██║██║░╚███║██║░╚██╗  ░░░██║░░░╚█████╔╝╚██████╔╝  ██║░░░░░╚█████╔╝██║░░██║
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝  ░░░╚═╝░░░░╚════╝░░╚═════╝░  ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝

██████╗░██╗░░░░░░█████╗░██╗░░░██╗██╗███╗░░██╗░██████╗░
██╔══██╗██║░░░░░██╔══██╗╚██╗░██╔╝██║████╗░██║██╔════╝░
██████╔╝██║░░░░░███████║░╚████╔╝░██║██╔██╗██║██║░░██╗░
██╔═══╝░██║░░░░░██╔══██║░░╚██╔╝░░██║██║╚████║██║░░╚██╗
██║░░░░░███████╗██║░░██║░░░██║░░░██║██║░╚███║╚██████╔╝
╚═╝░░░░░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝╚═╝░░╚══╝░╚═════╝░";


        static void Main(string[] args)
        {


            bool mainLoop = true;
            int playerChoice = 0;

            //The starting screen of the game

            Console.WriteLine(welcomeText);
            Console.WriteLine(miniDungeonText);
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

        /// <summary>
        /// Start a new game
        /// </summary>
        private static void NewGame()
        {

            _weapons = new List<Weapon>();

            _armors = new List<Armor>();

            _healingPotions = new List<HealingPotion>();

            _character = new Character();

            Console.Clear();

            Console.WriteLine(miniDungeonText);

            //Set the player to the initial location
            _character.newPlayer.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);

            //Add to player inventory the first 2 basic piece: a weapon and an armor 
            _character.newPlayer.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_THE_MIGHTY_WOODEN_STICK), 1));
            _character.newPlayer.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_THE_MIGHTY_USELESS_CLOTHES), 1));
            _character.newPlayer.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_HEALING_POTION), 1));

            Intro();

            AddWeaponsToWeaponList(_weapons);
            AddArmorsToArmorList(_armors);
            AddHealingPotionsToHealingPotionList(_healingPotions);

            RemoveWeaponsFromPlayerInventory();
            RemoveArmorsFromPlayerInventory();
            RemoveHealingPotionsFromPlayerInventory();

            _ = new MainM();

        }

        /// <summary>
        /// Check if the inventory item is a weapon and it's adding the weapon to the weapon list
        /// </summary>
        /// <param name="_weapons">List of weapons</param>
        private static void AddWeaponsToWeaponList(List<Weapon> _weapons)
        {
            foreach (InventoryItem ii in _character.newPlayer.Inventory)
            {
                if (ii.Details.IsWeapon)
                {
                    _weapons.Add((Weapon)ii.Details);
                }

            }
        }

        /// <summary>
        /// Check if the inventory item is an armor and it's adding the armor to the armor list
        /// </summary>
        /// <param name="_armors">List of armors</param>
        private static void AddArmorsToArmorList(List<Armor> _armors)
        {
            foreach (InventoryItem ii in _character.newPlayer.Inventory)
            {
                if (ii.Details.IsArmor)
                {
                    _armors.Add((Armor)ii.Details);
                }
            }
        }

        /// <summary>
        /// Check if the inventory item is a healing potion and it's adding the healing potion to 
        /// the healing potions list
        /// </summary>
        /// <param name="_healingPotions">List of healing potions</param>
        private static void AddHealingPotionsToHealingPotionList(List<HealingPotion> _healingPotions)
        {
            foreach (InventoryItem ii in _character.newPlayer.Inventory)
            {
                if (ii.Details.IsHealingPotion)
                {
                    _healingPotions.Add((HealingPotion)ii.Details);
                }
            }
        }

        /// <summary>
        /// Remove the weapons from the generic player inventory list
        /// </summary>
        private static void RemoveWeaponsFromPlayerInventory()
        {
            foreach (Weapon w in _weapons)
            {
                for (int i = 0; i < _character.newPlayer.Inventory.Count; i++)
                {
                    InventoryItem ii = _character.newPlayer.Inventory[i];
                    if (w.ID == ii.Details.ID)
                    {
                        _character.newPlayer.Inventory.Remove(ii);
                    }
                }
            }
        }

        /// <summary>
        /// Remove the armors from the generic player inventory list 
        /// </summary>
        private static void RemoveArmorsFromPlayerInventory()
        {
            foreach (Armor a in _armors)
            {
                for (int i = 0; i < _character.newPlayer.Inventory.Count; i++)
                {
                    InventoryItem ii = _character.newPlayer.Inventory[i];
                    if (a.ID == ii.Details.ID)
                    {
                        _character.newPlayer.Inventory.Remove(ii);
                    }
                }
            }
        }

        /// <summary>
        /// Remove the healing potions from the generic player inventory list 
        /// </summary>
        private static void RemoveHealingPotionsFromPlayerInventory()
        {
            foreach (HealingPotion hp in _healingPotions)
            {
                for (int i = 0; i < _character.newPlayer.Inventory.Count; i++)
                {
                    InventoryItem ii = _character.newPlayer.Inventory[i];
                    if (hp.ID == ii.Details.ID)
                    {
                        _character.newPlayer.Inventory.Remove(ii);
                    }
                }
            }
        }


        /// <summary>
        /// Show on the console all the available locations
        /// </summary>
        /// <param name="currentLocation"></param>
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

        /// <summary>
        /// Message for the wrong path
        /// </summary>
        private static void WrongPathMessage()
        {
            Console.Clear();
            Console.WriteLine(miniDungeonText);
            Console.WriteLine("You can't go there!");
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Player Stats
        /// </summary>
        private static void ShowPlayer()
        {
            Console.Clear();
            Console.WriteLine(miniDungeonText);
            PrintCharacter();
            Console.WriteLine();
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Show the map on console
        /// </summary>
        private static void ShowMap()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(miniDungeonText);
            Console.WriteLine("==================================");
            Console.WriteLine("                MAP               ");
            ShowAvailableLocations(_character.newPlayer.CurrentLocation);
            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Invalid input message
        /// </summary>
        private static void InvalidInput()
        {
            Console.Clear();
            Console.WriteLine(miniDungeonText);
            Console.WriteLine("Invalid Input! Try again!");
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// The intro of the game from a Narrator
        /// </summary>
        private static void Intro()
        {
            Console.WriteLine();

            Console.WriteLine("Narrator: A long time ago Compass house was an happy Town where people came just ");
            Console.WriteLine("          to spend their holidays and enjoy their life out of the busy life in Cambridge City.");
            Console.Write("[ENTER] to continue...");
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
            Console.WriteLine("Narrator: Take this weapon and this clothes, maybe they will help you during your journey.");
            Console.WriteLine("          Don't forget to equip them from your inventory!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(miniDungeonText);
            Console.WriteLine();
            Console.WriteLine("Weapon acquired: The Mighty Wooden Stick");
            Console.WriteLine("Armor acquired: The Mighty Useless Clothes");
            Console.WriteLine();
            Console.Write("[ENTER] to continue...");
            Console.ReadKey();
            Console.Clear();

        }

        /// <summary>
        /// Details of the stats of the player
        /// </summary>
        private static void PrintCharacter()
        {
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(" Name: " + _character.newPlayer.PlayerName);
            Console.WriteLine(" Race: " + _character.newPlayer.playerRace.ToString());
            Console.WriteLine(" Class: " + _character.newPlayer.playerClass.ToString());
            Console.WriteLine(" Level: " + _character.newPlayer.Level);
            Console.WriteLine(" Attack: " + _character.newPlayer.ClassMinimumDamage + " - " + _character.newPlayer.ClassMaximumDamage + " (" + _character.newPlayer.MinimumDamage + " - " + _character.newPlayer.MaximumDamage + ")");
            Console.WriteLine(" Defence: " + _character.newPlayer.ClassMinimumProtection + " - " + _character.newPlayer.ClassMaximumProtection + " (" + _character.newPlayer.MinimumProtection + " - " + _character.newPlayer.MaximumProtection + ")");
            Console.WriteLine(" Equip Weapon: " + _character.newPlayer.CurrentWeapon);
            Console.WriteLine(" Equip Armor: " + _character.newPlayer.CurrentArmor);
            Console.WriteLine(" HP: " + _character.newPlayer.CurrentHitPoints);
            Console.WriteLine(" Money: " + _character.newPlayer.Gold + " gold");
            Console.WriteLine(" XP: " + _character.newPlayer.ExperiencePoints);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


        }
    }
}
