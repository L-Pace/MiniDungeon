using System;
using System.Collections.Generic;

namespace MiniDungeon
{
    partial class Program
    {
        /// <summary>
        /// Explore Menu``
        /// </summary>
        public partial class ExploreM
        {
            /// <summary>
            /// Engage Fight calss
            /// </summary>
            public class EngageFightM
            {
                /// <summary>
                /// Engage Fight Menu contructor
                /// </summary>
                public EngageFightM()
                {
                    EngageFightInCurrentLocation(_character.newPlayer.CurrentLocation);
                }

                /// <summary>
                /// If there a moster in that location the player can engage a fight
                /// </summary>
                /// <param name="newLocation">Current location</param>
                private static void EngageFightInCurrentLocation(Location newLocation)
                {
                    // Check if there is a monster in that location if true we creating a monster there and a list of
                    //lootable items
                    if (newLocation.MonsterLivingHere != null)
                    {
                        Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                        _currentMonster = new Monster(standardMonster.ID,
                                                      standardMonster.Name,
                                                      standardMonster.MinimumDamage,
                                                      standardMonster.MaximumDamage,
                                                      standardMonster.MinimumProtection,
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
                    Console.WriteLine("*** MONSTER ENGAGED ***");
                    Console.WriteLine(" => " + _currentMonster.Name);
                    Console.WriteLine();
                    Console.WriteLine("<======MONSTER STATS======> ");
                    Console.WriteLine();
                    Console.WriteLine(" => Attack power: " + _currentMonster.MinimumDamage + " - " + _currentMonster.MaximumDamage);
                    Console.WriteLine(" => Defense power: " + _currentMonster.MinimumProtection + " - " + _currentMonster.MaximumProtection);
                    Console.WriteLine();
                    Console.WriteLine(" => HP: " + _currentMonster.CurrentHitPoints);
                    Console.WriteLine("<=========================>");
                    Console.WriteLine();
                    Console.WriteLine("<==========PLAYER STATS==========>");
                    Console.WriteLine();
                    Console.WriteLine(" => Weapon: " + _character.newPlayer.CurrentWeapon);
                    Console.WriteLine(" => Armor: " + _character.newPlayer.CurrentArmor);
                    Console.WriteLine();

                    PrintRightProtectionAndDamage();

                    Console.WriteLine();
                    Console.WriteLine(" => HP: " + _character.newPlayer.CurrentHitPoints + " HP");
                    Console.WriteLine("<=================================>");
                    Console.WriteLine();
                    Console.WriteLine("=======================================");
                    Console.WriteLine("| (A)ttack               | (I)nventory|");
                    Console.WriteLine("| (D)rink healing potion | (R)un away |");
                    Console.WriteLine("=======================================");
                    Console.WriteLine("| (B)ack |               ");
                    Console.Write(":> ");
                    string playerInput = Console.ReadLine().ToLower();

                    if (playerInput == "a" || playerInput == "attack")
                    {
                        AttackAction();
                    }
                    else if (playerInput == "i" || playerInput == "inventory")
                    {
                        _ = new InventoryM();
                    }
                    else if (playerInput == "d" || playerInput == "drink" || playerInput == "drink potion")
                    {
                        DrinkHealingPotion();
                    }
                    else if (playerInput == "r" || playerInput == "run away")
                    {
                        Console.Clear();
                        return;
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

                /// <summary>
                /// Shows on screen the stats of the player in case no weapons are equipped and viceversa
                /// </summary>
                private static void PrintRightProtectionAndDamage()
                {
                    if (_character.newPlayer.MaximumDamage != 0 && _character.newPlayer.MaximumProtection != 0)
                    {
                        Console.WriteLine(" => Attack power: " + _character.newPlayer.MinimumDamage + " - " + _character.newPlayer.MaximumDamage);
                        Console.WriteLine(" => Defense power: " + _character.newPlayer.MinimumProtection + " - " + _character.newPlayer.MaximumProtection);
                    }
                    else
                    {
                        Console.WriteLine(" => Attack power: " + _character.newPlayer.ClassMinimumDamage + " - " + _character.newPlayer.ClassMaximumDamage);
                        Console.WriteLine(" => Defense power: " + _character.newPlayer.ClassMinimumProtection + " - " + _character.newPlayer.ClassMaximumProtection);
                    }
                }

                /// <summary>
                /// The player perfmors the attack action
                /// </summary>
                private static void AttackAction()
                {
                    PlayerTurn();

                    if (_currentMonster.CurrentHitPoints <= 0)
                    {
                        MonsterDies();
                    }
                    else
                    {
                        MonsterTurn();

                        if (_character.newPlayer.CurrentHitPoints <= 0)
                        {
                            PlayerDies();
                        }
                        else
                        {
                            EngageFightMenu();
                        }
                    }
                }

                /// <summary>
                /// This method is choosing with a RandomNumberGenerator the monster attack power and the player defense power
                /// </summary>
                private static void MonsterTurn()
                {
                    int damageToPlayer;
                    int playerDefense;
                    int effectiveDamageToPlayer;

                    damageToPlayer = RandomNumberGenerator.NumberBetween(_currentMonster.MinimumDamage,
                                                                         _currentMonster.MaximumDamage);

                    if (_character.newPlayer.MinimumProtection != 0 && _character.newPlayer.MaximumProtection != 0)
                    {
                        playerDefense = RandomNumberGenerator.NumberBetween(_character.newPlayer.MinimumProtection,
                                                                            _character.newPlayer.MaximumProtection);

                        effectiveDamageToPlayer = MonsterTurnReport(damageToPlayer, playerDefense);
                    }
                    else
                    {
                        playerDefense = RandomNumberGenerator.NumberBetween(_character.newPlayer.ClassMinimumProtection,
                                                                            _character.newPlayer.ClassMaximumProtection);

                        effectiveDamageToPlayer = MonsterTurnReport(damageToPlayer, playerDefense);
                    }
                }

                /// <summary>
                /// Report of the monster turn
                /// </summary>
                /// <param name="damageToPlayer">Int of the damage to player</param>
                /// <param name="playerDefense">Int of the player defence</param>
                /// <returns></returns>
                private static int MonsterTurnReport(int damageToPlayer, int playerDefense)
                {
                    int effectiveDamageToPlayer;
                    Console.WriteLine();
                    Console.WriteLine("*** " + _currentMonster.Name + " turn ***");
                    Console.WriteLine();
                    Console.WriteLine(_currentMonster.Name + " is attacking you with " + damageToPlayer + " hit point/s.");
                    Console.WriteLine("You defending with " + playerDefense + " armor point/s.");

                    effectiveDamageToPlayer = CalcEffectiveDamageToPlayer(damageToPlayer, playerDefense);

                    Console.WriteLine("The " + _currentMonster.Name + " inflicted you " + effectiveDamageToPlayer + " damage point/s!");
                    Console.Write("[ENTER] to continue...");
                    Console.ReadKey();
                    return effectiveDamageToPlayer;
                }

                /// <summary>
                /// This method is choosing with a RandomNumberGenerator the player attack power and the monster defense power 
                /// </summary>
                private static void PlayerTurn()
                {
                    int damageToMonster;
                    int monsterDefense;
                    int effectiveDamageToMonster;

                    monsterDefense = RandomNumberGenerator.NumberBetween(_currentMonster.MinimumProtection,
                                                                         _currentMonster.MaximumProtection);

                    if (_character.newPlayer.MinimumDamage != 0 && _character.newPlayer.MaximumDamage != 0)
                    {
                        damageToMonster = RandomNumberGenerator.NumberBetween(_character.newPlayer.MinimumDamage,
                                                                              _character.newPlayer.MaximumDamage);

                        effectiveDamageToMonster = PlayerTurnReport(damageToMonster, monsterDefense);
                    }
                    else
                    {
                        damageToMonster = RandomNumberGenerator.NumberBetween(_character.newPlayer.ClassMinimumDamage,
                                                                              _character.newPlayer.ClassMaximumDamage);

                        effectiveDamageToMonster = PlayerTurnReport(damageToMonster, monsterDefense);
                    }
                }

                /// <summary>
                /// Report of the player turn
                /// </summary>
                /// <param name="damageToMonster">Player attack power</param>
                /// <param name="monsterDefense">Monster defense power</param>
                /// <returns></returns>
                private static int PlayerTurnReport(int damageToMonster, int monsterDefense)
                {
                    int effectiveDamageToMonster;
                    Console.Clear();
                    Console.WriteLine(fightText);
                    Console.WriteLine();
                    Console.WriteLine("** Your turn ***");
                    Console.WriteLine();
                    Console.WriteLine("You attacking with " + damageToMonster + " hit point/s.");
                    Console.WriteLine(_currentMonster.Name + " is defending with " + monsterDefense + " armor points.");

                    effectiveDamageToMonster = CalcEffectiveDamageToMonster(damageToMonster, monsterDefense);

                    Console.WriteLine("You hit " + _currentMonster.Name + " for " + effectiveDamageToMonster.ToString() + " point/s.");
                    Console.WriteLine("The " + _currentMonster.Name + " has " + _currentMonster.CurrentHitPoints + " HP left.");
                    Console.Write("[Enter] to continue...");
                    Console.ReadKey();
                    Console.WriteLine();
                    return effectiveDamageToMonster;
                }

                /// <summary>
                /// Player Dies and hp restored and respawn in location Home
                /// </summary>
                private static void PlayerDies()
                {
                    Console.Clear();
                    Console.WriteLine(deadText);
                    Console.WriteLine();
                    Console.WriteLine("You were our only hope to get rid of Viktor!");
                    Console.WriteLine("Now the only way is to call the priest in town ");
                    Console.WriteLine("and revive you!");
                    Console.Write("Press [Enter] to respawn in your 'Home'...");
                    Console.ReadKey();

                    _character.newPlayer.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
                    _character.newPlayer.CurrentHitPoints = _character.newPlayer.MaximumHitPoints;

                    Console.Clear();
                }

                /// <summary>
                /// Calculation of the damage from the moster to the player
                /// </summary>
                /// <param name="damageToPlayer">Monster attack power</param>
                /// <param name="playerDefense">Player defense power</param>
                /// <returns></returns>
                private static int CalcEffectiveDamageToPlayer(int damageToPlayer, int playerDefense)
                {
                    int effectiveDamageToPlayer = damageToPlayer - playerDefense;

                    if (effectiveDamageToPlayer <= 0)
                    {
                        effectiveDamageToPlayer = 0;
                    }
                    else
                    {
                        _character.newPlayer.CurrentHitPoints -= effectiveDamageToPlayer;
                    }

                    return effectiveDamageToPlayer;
                }

                /// <summary>
                /// Monster Dies and rewards are assigned to the player
                /// </summary>
                private static void MonsterDies()
                {
                    Console.Clear();
                    Console.WriteLine(victoryText);
                    Console.WriteLine();
                    _character.newPlayer.ExperiencePoints += _currentMonster.RewardExperiencePoints;
                    Console.WriteLine("You receive " + _currentMonster.RewardExperiencePoints.ToString() + " XP.");

                    _character.newPlayer.Gold += _currentMonster.RewardGold;
                    Console.WriteLine("You receive " + _currentMonster.RewardGold.ToString() + " gold!");

                    ManageLoot();

                    Console.Write("[ENTER] to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }

                /// <summary>
                /// Assignment of the loot when the monster dies
                /// </summary>
                private static void ManageLoot()
                {
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
                }

                /// <summary>
                /// Calculation of the damage from the player to the monster
                /// </summary>
                /// <param name="damageToMonster">Player attack power</param>
                /// <param name="monsterDefense">Monster defense power</param>
                /// <returns></returns>
                private static int CalcEffectiveDamageToMonster(int damageToMonster, int monsterDefense)
                {
                    int effectiveDamageToMonster = damageToMonster - monsterDefense;
                    if (effectiveDamageToMonster <= 0)
                    {
                        effectiveDamageToMonster = 0;
                    }
                    else
                    {
                        _currentMonster.CurrentHitPoints -= effectiveDamageToMonster;
                    }

                    return effectiveDamageToMonster;
                }
            }
        }
    }
}

