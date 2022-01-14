using System;
using System.Collections.Generic;

namespace MiniDungeon
{
    public partial class Program
    {
        public partial class InventoryM
        {

            public InventoryM()
            {
                InventoryMenu();
            }

            private static void InventoryMenu()
            {
                string playerInput;

                Console.Clear();
                Console.WriteLine(miniDungeonText);
                Console.WriteLine(inventoryText);
                Console.WriteLine();

                ShowInventory();

                Console.WriteLine();
                Console.WriteLine("=================================");
                Console.WriteLine("| Equip (W)eapon | Equip (A)rmor|");
                Console.WriteLine("=================================");
                Console.WriteLine("| (B)ack |                       ");
                Console.Write(":> ");
                playerInput = Console.ReadLine().ToLower();

                if (playerInput == "w" || playerInput == "equip weapon" || playerInput == "weapon")
                {
                    EquipWeapon();
                }
                else if (playerInput == "a" || playerInput == "equip armor" || playerInput == "armor")
                {
                    //EquipArmor();
                }
                else if (playerInput == "b" || playerInput == "back")
                {
                    return;
                }
                else
                {
                    InvalidInput();
                }


            }

            private static void EquipWeapon()
            {
                int playerInput = 0;

                Console.WriteLine("Insert Weapon ID:");
                Console.Write(":> ");
                while (!int.TryParse(Console.ReadLine(), out playerInput))
                {
                    Console.WriteLine("Invalid input! Try again!");
                    Console.WriteLine("Insert Weapon ID:");
                    Console.Write(":> ");
                }

                foreach(Weapon w in _weapons)
                {
                    if(playerInput == w.ID)
                    {
                        //Weapon currentWeapon = w.ID;
                    }
                }
            }

            private static void ShowInventory()
            {
                Console.WriteLine("*** WEAPONS ***");
                Console.WriteLine();
                ShowWeapons();

                Console.WriteLine();
                Console.WriteLine("*** ARMORS ***");
                Console.WriteLine();
                ShowArmors();

                Console.WriteLine();
                Console.WriteLine("*** POTIONS ***");
                Console.WriteLine();
                ShowHealingPotions();

                Console.WriteLine();
                Console.WriteLine("*** ITEMS ****");
                Console.WriteLine();
                ShowInventoryItem();
            }

            private static void ShowWeapons()
            {

                if (_weapons.Count != 0)
                {
                    foreach (Weapon w in _weapons)
                    {
                        Console.WriteLine("==================");
                        Console.WriteLine("Name: " + w.Name);
                        Console.WriteLine("ID: " + w.ID.ToString());
                        Console.WriteLine("Min Damage: " + w.MinimumDamage);
                        Console.WriteLine("Max Damage: " + w.MaximumDamage);
                        Console.WriteLine("Value: " + w.Price + " gold");
                        Console.WriteLine("==================");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("There are no weapons in the inventory!");
                }
            }


            private static void ShowArmors()
            {


                if (_armors.Count != 0)
                {

                    foreach (Armor a in _armors)
                    {
                        Console.WriteLine("==================");
                        Console.WriteLine("Name: " + a.Name);
                        Console.WriteLine("ID: " + a.ID.ToString());
                        Console.WriteLine("Min Protection: " + a.MinimumProtection);
                        Console.WriteLine("Max Protection: " + a.MaximumProtection);
                        Console.WriteLine("Value: " + a.Price + " gold");
                        Console.WriteLine("==================");
                        Console.WriteLine();
                    } 
                }
                else
                {
                    Console.WriteLine("There are no armors in the inventory!");
                }

            }

            private static void ShowHealingPotions()
            {


                if (_healingPotions.Count != 0)
                {
                    foreach (HealingPotion hp in _healingPotions)
                    {
                        Console.WriteLine("=================");
                        Console.WriteLine("Name: " + hp.Name);
                        Console.WriteLine("Heals " + hp.AmountToHeal + " HP");
                        Console.WriteLine("Value: " + hp.Price);
                        Console.WriteLine("=================");
                    } 
                }
                else
                {
                    Console.WriteLine("There are no potions in your inventory!");
                }
            }

            private static void ShowInventoryItem()
            {


                if (_player.Inventory.Count != 0)
                {
                    foreach (InventoryItem ii in _player.Inventory)
                    {
                        Console.WriteLine("=================");
                        Console.WriteLine("Name: " + ii.Details.Name);
                        Console.WriteLine("Quantity: " + ii.Quantity);
                        Console.WriteLine("Value: " + ii.Details.Price);
                        Console.WriteLine("=================");
                    }
                }
                else
                {
                    Console.WriteLine("There no keys or regular items in your inventory!");
                }
            }
        }




    }

}

