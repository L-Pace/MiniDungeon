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
                    EngageFightMenu(_player.CurrentLocation);
                }
                private static void EngageFightMenu(Location newLocation)
                {
                    string playerInput;

                    if (newLocation.MonsterLivingHere != null)
                    {
                        Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                        _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage, standardMonster.MaximumProtection, standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

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
                    Console.WriteLine("| (B)ack |                         ");
                    Console.Write(":> ");
                    playerInput = Console.ReadLine().ToLower();

                    if (playerInput == "a" || playerInput == "attack")
                    {
                        AttackAction();
                    }
                    else if(playerInput == "i" || playerInput == "inventory")
                    {
                        //Inventory
                    }
                    else if(playerInput == "d" || playerInput == "defend")
                    {
                        //defend
                    }
                    else if(playerInput == "r" || playerInput == "run away")
                    {
                        //run away
                    }
                    else if(playerInput == "b" || playerInput == "back")
                    {
                        return;
                    }
                    else
                    {
                        InvalidInput();
                    }
                }


                private static void AttackAction()
                {

                    //Weapon currentWeapon = ;

                }

                
            }
        }
    }
}

