using System;
using System.Collections.Generic;


namespace MiniDungeon
{
    partial class Program
    {
        /// <summary>
        /// Explore menu` class
        /// </summary>
        public partial class ExploreM
        {
            /// <summary>
            /// This supposed to be the menu` for the shop. Unfortunately is still not complete so I decided to leave it as it is but with no references inside of the main project
            /// </summary>
            public partial class ShopM
            {
                private static string theNerdShrineBanner = @"
████████╗██╗░░██╗███████╗  ███╗░░██╗███████╗██████╗░██████╗░  ░██████╗██╗░░██╗██████╗░██╗███╗░░██╗███████╗
╚══██╔══╝██║░░██║██╔════╝  ████╗░██║██╔════╝██╔══██╗██╔══██╗  ██╔════╝██║░░██║██╔══██╗██║████╗░██║██╔════╝
░░░██║░░░███████║█████╗░░  ██╔██╗██║█████╗░░██████╔╝██║░░██║  ╚█████╗░███████║██████╔╝██║██╔██╗██║█████╗░░
░░░██║░░░██╔══██║██╔══╝░░  ██║╚████║██╔══╝░░██╔══██╗██║░░██║  ░╚═══██╗██╔══██║██╔══██╗██║██║╚████║██╔══╝░░
░░░██║░░░██║░░██║███████╗  ██║░╚███║███████╗██║░░██║██████╔╝  ██████╔╝██║░░██║██║░░██║██║██║░╚███║███████╗
░░░╚═╝░░░╚═╝░░╚═╝╚══════╝  ╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝╚═════╝░  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝╚═╝░░╚══╝╚══════╝";


                private static string showItemsBanner = @"
█▀ █░█ █▀█ █░█░█   █ ▀█▀ █▀▀ █▀▄▀█ █▀
▄█ █▀█ █▄█ ▀▄▀▄▀   █ ░█░ ██▄ █░▀░█ ▄█";

                private static string weaponsBanner = @"
█░█░█ █▀▀ ▄▀█ █▀█ █▀█ █▄░█ █▀
▀▄▀▄▀ ██▄ █▀█ █▀▀ █▄█ █░▀█ ▄█";

                private static string armorsBanner = @"
▄▀█ █▀█ █▀▄▀█ █▀█ █▀█ █▀
█▀█ █▀▄ █░▀░█ █▄█ █▀▄ ▄█";

                private static string healingItemsBanner = @"
█░█ █▀▀ ▄▀█ █░░ █ █▄░█ █▀▀   █ ▀█▀ █▀▀ █▀▄▀█ █▀
█▀█ ██▄ █▀█ █▄▄ █ █░▀█ █▄█   █ ░█░ ██▄ █░▀░█ ▄█";


                public ShopM()
                {
                    ShopMenu(_character.newPlayer.CurrentLocation);
                }

                private static void ShopMenu(Location newLocation)
                {
                    string playerInput;
                    bool shopMenuLoop = true;



                    while (shopMenuLoop)
                    {
                        Console.Clear();
                        Console.WriteLine(theNerdShrineBanner);
                        Console.WriteLine();
                        Console.WriteLine("=>" + newLocation.NpcLivingHere.Name);
                        Console.WriteLine();
                        Console.WriteLine("<-------------------------------------------------------------->");
                        Console.WriteLine(newLocation.NpcLivingHere.Dialogue);
                        Console.WriteLine("<-------------------------------------------------------------->");
                        Console.WriteLine();
                        Console.WriteLine("========================================");
                        Console.WriteLine("| (B)uy Items   |   Show (I)tems       |");
                        Console.WriteLine("| (S)ell Items  |   (P)layer Inventory |  |");
                        Console.WriteLine("========================================");
                        Console.WriteLine("| (Ba)ck |            | (O)ptions |");
                        Console.WriteLine();
                        Console.Write(":> ");
                        playerInput = Console.ReadLine();
                        if (playerInput == "b" || playerInput == "buy" || playerInput == "buy items")
                        {
                            //BuyItems();
                        }
                        else if (playerInput == "s" || playerInput == "sell" || playerInput == "sell items")
                        {
                            //SellItems();      
                        }
                        else if (playerInput == "i" || playerInput == "show items")
                        {
                            //ShowShopItems();
                        }
                        else if (playerInput == "o" || playerInput == "options")
                        {
                            //OptionsMenu();
                        }
                        else if (playerInput == "ba" || playerInput == "back")
                        {
                            return;
                        }
                        else
                        {
                            InvalidInput();
                        }
                        //Console.ReadKey();
                        //shopMenuLoop = false;
                    }
                }

                private static void ShowShopItems()
                {
                    string playerInput;
                    bool showShopItemsLoop = true;

                    while (showShopItemsLoop)
                    {
                        Console.Clear();
                        Console.WriteLine(showItemsBanner);
                        Console.WriteLine();
                        Console.WriteLine("Select the category to view");
                        Console.WriteLine();
                        Console.WriteLine("========================================");
                        Console.WriteLine("| (W)eapons          |   (A)rmors       |");
                        Console.WriteLine("| (H)ealing Potions  |                  |");
                        Console.WriteLine("========================================");
                        Console.WriteLine("| (Ba)ck |            | (O)ptions |");
                        Console.WriteLine();
                        Console.Write(":> ");
                        playerInput = Console.ReadLine();
                        if (playerInput == "w" || playerInput == "weapons")
                        {
                            //ShowWeapons();
                        }
                        else if (playerInput == "a" || playerInput == "armors")
                        {
                            ShowArmors();
                        }
                        else if (playerInput == "h" || playerInput == "healing" || playerInput == "healing potions")
                        {
                            ShowHealingPotions();
                        }
                        else if (playerInput == "o" || playerInput == "options")
                        {
                            //OptionsMenu();
                        }
                        else if (playerInput == "ba" || playerInput == "back")
                        {
                            return;
                        }
                        else
                        {
                            InvalidInput();
                        }
                        showShopItemsLoop = false;
                    }
                }

                private static void ShowHealingPotions()
                {
                    Console.Clear();
                    Console.WriteLine(theNerdShrineBanner);
                    Console.WriteLine(weaponsBanner);
                    Console.WriteLine();
                    foreach (InventoryItem ii in _character.newPlayer.CurrentLocation.VendorWorkingHere.Inventory)
                    {
                        if (ii.Details.IsHealingPotion == true)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine("Name: " + ii.Details.Name);
                            //1
                            //Console.WriteLine("Attack Power: " + ii.)
                            Console.WriteLine("Price: " + ii.Details.Price);
                            Console.WriteLine("Quantity: " + ii.Quantity);
                        }
                    }
                    Console.Write("[ENTER] to go back...");
                    Console.ReadKey();
                }

                private static void ShowArmors()
                {
                    Console.Clear();
                    Console.WriteLine(theNerdShrineBanner);
                    Console.WriteLine(armorsBanner);
                    Console.WriteLine();

                    foreach (Armor a in World.Items)
                    {
                        foreach (InventoryItem ii in _character.newPlayer.CurrentLocation.VendorWorkingHere.Inventory)
                        {
                            if (ii.Details.IsArmor == true)
                            {
                                Console.WriteLine("Name: " + ii.Details.Name);
                                if (ii.Details.ID == a.ID)
                                {
                                    Console.WriteLine("Defense Power: " + a.MinimumProtection + " - " + a.MaximumProtection);
                                }
                                Console.WriteLine("Price: " + ii.Details.Price);
                                Console.WriteLine("Quantity: " + ii.Quantity);
                            }
                        }
                    }

                    Console.Write("[ENTER] to go back...");
                    Console.ReadKey();
                }

                private static void ShowWeapons()
                {
                    List<InventoryItem> shopWeapon = new List<InventoryItem>();

                    Console.Clear();
                    Console.WriteLine(theNerdShrineBanner);
                    Console.WriteLine(weaponsBanner);
                    Console.WriteLine();
                    foreach (InventoryItem ii in _character.newPlayer.CurrentLocation.VendorWorkingHere.Inventory)
                    {
                            if (ii.Details.IsWeapon == true)
                            {
                                Console.WriteLine("Name: " + ii.Details.Name);
                                Console.WriteLine("Price: " + ii.Details.Price);
                                Console.WriteLine("Quantity: " + ii.Quantity);
                            }
                     
                    }
                    Console.Write("[ENTER] to go back...");
                    Console.ReadKey();
                }
            }
        }
    }
}