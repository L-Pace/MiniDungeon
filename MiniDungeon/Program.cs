using System;
using System.Collections.Generic;

namespace MiniDungeon
{
    partial class Program
    {

        private static Player _player = new Player(0, 0, 0, 0, 0, 0, 0, 0, 0);
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

        private static string questBookText = @"
█▀█ █░█ █▀▀ █▀ ▀█▀   █▄▄ █▀█ █▀█ █▄▀
▀▀█ █▄█ ██▄ ▄█ ░█░   █▄█ █▄█ █▄█ █░█";

        private static string inventoryText = @"
█ █▄░█ █░█ █▀▀ ▀█▀ █▀█ █▀█ █▄█
█ █░▀█ ▀▄▀ ██▄ ░█░ █▄█ █▀▄ ░█░";


        static void Main(string[] args)
        {


            bool mainLoop = true;
            int playerChoice = 0;

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

        private static void NewGame()
        {
            _weapons = new List<Weapon>();

            _armors = new List<Armor>();

            _healingPotions = new List<HealingPotion>();

            _character = new Character();

            Console.Clear();

            Console.WriteLine(miniDungeonText);

            //Intro();

            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

            AddWeaponsToWeaponList(_weapons);
            AddArmorsToArmorList(_armors);
            AddHealingPotionsToHealingPotionList(_healingPotions);

            RemoveWeaponsFromPlayerInventory();
            RemoveArmorsFromPlayerInventory();
            RemoveHealingPotionsFromPlayerInventory();

            _ = new MainM();

        }

        private static void AddWeaponsToWeaponList(List<Weapon> _weapons)
        {
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.IsWeapon)
                {
                    _weapons.Add((Weapon)ii.Details);   
                }   
            }
        }

        private static void AddArmorsToArmorList(List<Armor> _armors)
        {
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.IsArmor)
                {
                    _armors.Add((Armor)ii.Details);
                }
            }
        }

        private static void AddHealingPotionsToHealingPotionList(List<HealingPotion> _healingPotions)
        {
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.IsHealingPotion)
                {
                    _healingPotions.Add((HealingPotion)ii.Details);
                }
            }
        }

        private static void RemoveWeaponsFromPlayerInventory()
        {
            foreach(Weapon w in _weapons)
            {
                for (int i = 0; i < _player.Inventory.Count; i++)
                {
                    InventoryItem ii = _player.Inventory[i];
                    if (w.ID == ii.Details.ID)
                    {
                        _player.Inventory.Remove(ii);
                    }
                }
            }
        }

        private static void RemoveArmorsFromPlayerInventory()
        {
            foreach (Armor a in _armors)
            {
                for (int i = 0; i < _player.Inventory.Count; i++)
                {
                    InventoryItem ii = _player.Inventory[i];
                    if (a.ID == ii.Details.ID)
                    {
                        _player.Inventory.Remove(ii);
                    }
                }
            }
        }

        private static void RemoveHealingPotionsFromPlayerInventory()
        {
            foreach(HealingPotion hp in _healingPotions)
            {
                for (int i = 0; i < _player.Inventory.Count; i++)
                {
                    InventoryItem ii = _player.Inventory[i];
                    if (hp.ID == ii.Details.ID)
                    {
                        _player.Inventory.Remove(ii);
                    }
                }
            }
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

        private static void WrongPathMessage()
        {
            Console.Clear();
            Console.WriteLine(miniDungeonText);
            Console.WriteLine("You can't go there!");
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ShowPlayer()
        {
            Console.Clear();
            Console.WriteLine(miniDungeonText);
            _character.PrintCharacter();
            Console.WriteLine(_player.MaximumDamage);
            Console.WriteLine();
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }


        private static void ShowMap()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(miniDungeonText);
            Console.WriteLine("==================================");
            Console.WriteLine("                MAP               ");
            ShowAvailableLocations(_player.CurrentLocation);
            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

        private static void InvalidInput()
        {
            Console.Clear();
            Console.WriteLine(miniDungeonText);
            Console.WriteLine("Invalid Input! Try again!");
            Console.Write("[ENTER] to go back");
            Console.ReadKey();
            Console.Clear();
        }

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
            Console.ReadKey();
            Console.Clear();

        }
    }
}
