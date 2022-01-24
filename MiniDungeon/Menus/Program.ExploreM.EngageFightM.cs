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
                    EngageFightMenu(_character.newPlayer.CurrentLocation);
                }
                private static void EngageFightMenu(Location newLocation)
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
                    playerInput = Console.ReadLine().ToLower();

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

                    int damageToMonster = RandomNumberGenerator.NumberBetween(_character.newPlayer.MinimumDamage, _character.newPlayer.MaximumDamage);

                    _currentMonster.CurrentHitPoints -= damageToMonster;

                    Console.WriteLine("You hit " + _currentMonster.Name + " for " + damageToMonster.ToString() + " points.");

                    if (_currentMonster.CurrentHitPoints <= 0)
                    {
                        Console.WriteLine("You defeted the " + _currentMonster.Name);
                        Console.WriteLine("You receive " + _currentMonster.RewardExperiencePoints.ToString() + " experience points.");

                        _character.newPlayer.ExperiencePoints += _currentMonster.RewardGold;

                        Console.WriteLine("You receive " + _currentMonster.RewardGold.ToString() + " golds");

                        List<InventoryItem> lootedItems = new List<InventoryItem>();

                        foreach (LootItem lootItem in _currentMonster.LootTable)
                        {
                            if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                            {
                                _character.newPlayer.Inventory.Add(new InventoryItem(lootItem.Details, 1));
                                AddWeaponsToWeaponList(_weapons);
                                AddArmorsToArmorList(_armors);
                                AddHealingPotionsToHealingPotionList(_healingPotions);

                                RemoveWeaponsFromPlayerInventory();
                                RemoveArmorsFromPlayerInventory();
                                RemoveHealingPotionsFromPlayerInventory();
                            }
                        }
                        if (lootedItems.Count == 0)
                        {
                            foreach (LootItem lootItem in _currentMonster.LootTable)
                            {
                                if (lootItem.IsDefaultItem)
                                {
                                    _character.newPlayer.Inventory.Add(new InventoryItem(lootItem.Details, 1));
                                }
                            }
                        }
                    }


                }


            }
        }
    }
}

