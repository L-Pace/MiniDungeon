using System;
using System.Collections.Generic;

namespace MiniDungeon
{
    partial class Program
    {
        public partial class ExploreM
        {
            public class EngageFightM
            {
                public EngageFightM()
                {
                    EngageFightInCurrentLocation(_character.newPlayer.CurrentLocation);
                }
                private static void EngageFightInCurrentLocation(Location newLocation)
                {
                    string playerInput;

                    if (newLocation.MonsterLivingHere != null)
                    {
                        Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                        _currentMonster = new Monster(standardMonster.ID,
                                                      standardMonster.Name,
                                                      standardMonster.MaximumDamage,
                                                      standardMonster.MaximumProtection,
                                                      standardMonster.RewardExperiencePoints,
                                                      standardMonster.RewardGold,
                                                      standardMonster.CurrentHitPoints,
                                                      standardMonster.MaximumHitPoints);

                        foreach (LootItem lootItem in standardMonster.LootTable)
                        {
                            _currentMonster.LootTable.Add(lootItem);
                        }
                    }
                    else
                    {
                        _currentMonster = null;
                    }

                    //AddItemToRightList(_weapons, _armors, _healingPotions);

                    EngageFightMenu();
                }

                /// <summary>
                /// Engage Fight Menu
                /// </summary>
                private static void EngageFightMenu()
                {
                    Console.Clear();
                    Console.WriteLine(miniDungeonText);
                    Console.WriteLine(fightText);
                    Console.WriteLine();
                    Console.WriteLine("=========================");
                    Console.WriteLine("| (A)ttack | (I)nventory|");
                    Console.WriteLine("| (D)efend | (R)un away |");
                    Console.WriteLine("=========================");
                    Console.WriteLine("| (B)ack |               ");
                    Console.Write(":> ");
                    string playerInput = Console.ReadLine().ToLower();

                    if (playerInput == "a" || playerInput == "attack")
                    {
                        AttackAction();
                    }
                    else if (playerInput == "i" || playerInput == "inventory")
                    {
                        //Inventory
                    }
                    else if (playerInput == "d" || playerInput == "defend")
                    {
                        //defend
                    }
                    else if (playerInput == "r" || playerInput == "run away")
                    {
                        //run away
                    }
                    else if (playerInput == "b" || playerInput == "back")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        InvalidInput();
                    }
                }

                private static void AttackAction()
                {

                    int damageToMonester = RandomNumberGenerator.NumberBetween(_character.newPlayer.MinimumDamage,
                                                                               _character.newPlayer.MaximumDamage);
                    _currentMonster.CurrentHitPoints -= damageToMonester;

                    Console.WriteLine("You hit " + _currentMonster.Name + " for " + damageToMonester.ToString() + " points");

                    Console.WriteLine("The " + _currentMonster.Name + " has " + _currentMonster.CurrentHitPoints + " HP left.");
                    Console.ReadKey();

                    if (_currentMonster.CurrentHitPoints <= 0)
                    {
                        Console.WriteLine("The " + _currentMonster.Name + " is dead!");
                        _character.newPlayer.ExperiencePoints += _currentMonster.RewardExperiencePoints;
                        Console.WriteLine("You receive " + _currentMonster.RewardExperiencePoints.ToString() + " XP");

                        _character.newPlayer.Gold += _currentMonster.RewardGold;
                        Console.WriteLine("You receive " + _currentMonster.RewardGold.ToString() + " gold!");

                        List<InventoryItem> lootedItem = new List<InventoryItem>();

                        foreach (LootItem lootItem in _currentMonster.LootTable)
                        {
                            if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                            {
                                lootedItem.Add(new InventoryItem(lootItem.Details, 1));
                            }
                        }

                        if (lootedItem.Count == 0)
                        {
                            foreach (LootItem lootItem in _currentMonster.LootTable)
                            {
                                if (lootItem.IsDefaultItem)
                                {
                                    lootedItem.Add(new InventoryItem(lootItem.Details, 1));
                                }
                            }
                        }

                        foreach (InventoryItem inventoryItem in lootedItem)
                        {
                            _character.newPlayer.Inventory.Add(new InventoryItem(inventoryItem.Details, 1));

                            AddWeaponsToWeaponList(_weapons);
                            AddArmorsToArmorList(_armors);

                            RemoveArmorsFromPlayerInventory();
                            RemoveWeaponsFromPlayerInventory();

                            if (inventoryItem.Quantity == 1)
                            {
                                Console.WriteLine("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name);
                            }
                            else
                            {
                                Console.WriteLine("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name);
                            }
                        }

                        Console.ReadKey();
                    }
                    else
                    {
                        int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);

                        Console.WriteLine("The " + _currentMonster.Name + " inflicted you " + damageToPlayer + " damage points!");

                        _character.newPlayer.CurrentHitPoints -= damageToPlayer;

                        Console.ReadKey();

                        if (_character.newPlayer.CurrentHitPoints <= 0)
                        {
                            Console.WriteLine("The " + _currentMonster.Name + " killed you!");

                            Console.ReadKey();
                            _character.newPlayer.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
                        }
                        else
                        {
                            EngageFightMenu();
                        }
                    }
                }
            }
        }
    }
}

