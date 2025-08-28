using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniDungeon
{
    public partial class Program
    {
        /// <summary>
        /// Inventory Menu` 
        /// </summary>
        public partial class InventoryM
        {
            /// <summary>
            /// Inventory Menu` contructor
            /// </summary>
            public InventoryM()
            {
                InventoryMenu();
            }

            /// <summary>
            /// Method that shows the Inventory menu`
            /// </summary>
            private static void InventoryMenu()
            {
                string playerInput;

                Console.Clear();
                Console.WriteLine(miniDungeonText);
                Console.WriteLine(inventoryText);
                Console.WriteLine();

                ShowInventory();

                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("| Equip (W)eapon       |  Equip (A)rmor|");
                Console.WriteLine("| (D)rop (W)eapon      | (D)rop (A)rmor|");
                Console.WriteLine("| Drink (H)eling Potion|");
                Console.WriteLine("=======================================");
                Console.WriteLine("| (B)ack |                       ");
                Console.Write(":> ");
                playerInput = Console.ReadLine().ToLower();

                if (playerInput == "w" || playerInput == "equip weapon" || playerInput == "weapon")
                {
                    EquipWeapon();
                }
                else if (playerInput == "a" || playerInput == "equip armor" || playerInput == "armor")
                {
                    EquipArmor();
                }
                else if (playerInput == "dw" || playerInput == "drop weapon")
                {
                    // This is the method to drop the weapons from the inventory. Still work in process
                    //DropWeapon();
                }
                else if (playerInput == "da" || playerInput == "drop armor")
                {
                    // This is the method to drop the armors from the inventory. Still work in process
                    //DropArmor();
                }
                else if (playerInput == "h" || playerInput == "drink" || playerInput == "drink healing potion")
                {
                    DrinkHealingPotion();
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

            /// <summary>
            /// Use a healing potion
            /// </summary>
            static void DrinkHealingPotion()
            {
                int playerInput = 0;

                ShowHealingPotions();

                Console.WriteLine("Insert Healing Potion ID:");
                Console.Write(":> ");
                while (!int.TryParse(Console.ReadLine(), out playerInput))
                {
                    Console.WriteLine("Invalid input! Try again!");
                    Console.WriteLine("Insert Armor ID:");
                    Console.Write(":> ");
                }

                foreach (HealingPotion h in _healingPotions.ToList())
                {
                    if (playerInput == h.ID)
                    {
                        _character.newPlayer.CurrentHitPoints += h.AmountToHeal;
                        if(_character.newPlayer.CurrentHitPoints > _character.newPlayer.MaximumHitPoints)
                        {
                            _character.newPlayer.CurrentHitPoints += h.AmountToHeal;
                            _character.newPlayer.CurrentHitPoints = _character.newPlayer.MaximumHitPoints;
                            RemoveHealingPotionFromHealingPotionList(h.ID);
                        }
                        else
                        {
                            _character.newPlayer.CurrentHitPoints += h.AmountToHeal;
                            RemoveHealingPotionFromHealingPotionList(h.ID);
                        }
                    }
                }
            }

            private static void RemoveHealingPotionFromHealingPotionList(int id)
            {
                foreach (HealingPotion h in _healingPotions.ToList())
                {
                    var healingPotionToRemove = _healingPotions.SingleOrDefault(r => r.ID == id);
                    if (healingPotionToRemove != null)
                    {
                        _healingPotions.Remove(healingPotionToRemove);
                    }
                }
            }

            /// <summary>
            /// Drop a weapon. Work in Progress
            /// </summary>
            private static void DropWeapon()
            {
                int playerInput = 0;
                int i = 0;

                Console.WriteLine("Insert Weapon ID:");
                Console.Write(":> ");
                while (!int.TryParse(Console.ReadLine(), out playerInput))
                {
                    Console.WriteLine("Invalid input! Try again!");
                    Console.WriteLine("Insert Armor ID:");
                    Console.Write(":> ");
                }

                if (_weapons != null)
                {
                    foreach (Weapon weapon in _weapons)
                    {
                        if (playerInput == weapon.ID)
                        {
                            i++;
                        }
                    }

                    switch (i)
                    {
                        case 1:
                            var weaponToRemove = _weapons.SingleOrDefault(r => r.ID == i);

                            Console.WriteLine("You have just one weapon of this kind.");
                            Console.WriteLine("Are you sure to drop it?");
                            break;
                    }

                }
            }

            /// <summary>
            /// Equip an armor from the weapon list
            /// </summary>
            private static void EquipArmor()
            {
                int playerInput = 0;

                Console.WriteLine("Insert Armor ID:");
                Console.Write(":> ");
                while (!int.TryParse(Console.ReadLine(), out playerInput))
                {
                    Console.WriteLine("Invalid input! Try again!");
                    Console.WriteLine("Insert Armor ID:");
                    Console.Write(":> ");
                }

                foreach (Armor a in _armors)
                {
                    if (playerInput == a.ID)
                    {
                        _character.newPlayer.MaximumProtection = _character.newPlayer.ClassMaximumProtection + a.MaximumProtection;

                        _character.newPlayer.MinimumProtection = _character.newPlayer.ClassMinimumProtection + a.MinimumProtection;

                        _character.newPlayer.CurrentArmor = a.Name;
                    }
                }
            }

            /// <summary>
            /// Equip a weapon from the weapon list
            /// </summary>
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

                foreach (Weapon w in _weapons)
                {
                    if (playerInput == w.ID)
                    {
                        _character.newPlayer.MaximumDamage = _character.newPlayer.ClassMaximumDamage + w.MaximumDamage;

                        _character.newPlayer.MinimumDamage = _character.newPlayer.ClassMinimumDamage + w.MinimumDamage;

                        _character.newPlayer.CurrentWeapon = w.Name;
                    }
                }

            }

            /// <summary>
            /// Shows the inventory from the lists 
            /// </summary>
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

            /// <summary>
            /// Show the stats of every weapon in weapon list
            /// </summary>
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

            /// <summary>
            /// Shows stats of every armor in armor list
            /// </summary>
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

            /// <summary>
            /// Shows healing potion in healing potion list
            /// </summary>
            private static void ShowHealingPotions()
            {
                if (_healingPotions.Count != 0)
                {
                    foreach (HealingPotion hp in _healingPotions)
                    {
                        Console.WriteLine("=================");
                        Console.WriteLine("Name: " + hp.Name);
                        Console.WriteLine("ID:" + hp.ID);
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


            /// <summary>
            /// Show normal inventory items (quest items, keys)
            /// </summary>
            private static void ShowInventoryItem()
            {
                if (_character.newPlayer.Inventory.Count != 0)
                {
                    foreach (InventoryItem ii in _character.newPlayer.Inventory)
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

