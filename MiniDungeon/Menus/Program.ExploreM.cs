using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniDungeon
{
    partial class Program
    {
        public partial class ExploreM
        {
            public ExploreM()
            {
                ExploreMenu();
            }

            /// <summary>
            /// This menu` is redirecting the player on Talk with NPC, Engage a Fight with a monster. The player can have a look on their inventory and the stats as well
            /// </summary>
            private static void ExploreMenu()
            {
                string playerInput;
                bool exploreMenuLoop = true;


                while (exploreMenuLoop)
                {
                    Console.Clear();
                    Console.WriteLine(miniDungeonText);
                    Console.WriteLine();
                    Console.WriteLine("*** CURRENT LOCATION ***");
                    Console.WriteLine(" =>" + _character.newPlayer.CurrentLocation.Name.ToString());
                    Console.WriteLine();
                    Console.WriteLine("*** INFO LOCATION ***");
                    Console.WriteLine("<-------------------------------------------------->");
                    NPCLivingHereChecker(_character.newPlayer.CurrentLocation);
                    Console.WriteLine();
                    MonsterLivingHereChecker(_character.newPlayer.CurrentLocation);
                    Console.WriteLine("<-------------------------------------------------->");
                    Console.WriteLine();
                    Console.WriteLine("===================================");
                    Console.WriteLine("| (T)alk         |   Show (P)layer|");
                    Console.WriteLine("| (E)ngage fight |   (I)nventory  |");
                    Console.WriteLine("===================================");
                    Console.WriteLine("| (B)ack |            | (O)ptions |");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write(":> ");
                    playerInput = Console.ReadLine();

                    if (playerInput == "t" || playerInput == "talk")
                    {
                        QuestChecker(_character.newPlayer.CurrentLocation);
                        exploreMenuLoop = false;
                    }
                    else if (playerInput == "e" || playerInput == "engage" || playerInput == "fight" || playerInput == "engage fight")
                    {
                        if (_character.newPlayer.CurrentLocation.MonsterLivingHere != null)
                        {
                            _ = new EngageFightM();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (playerInput == "i" || playerInput == "inventory")
                    {
                        _ = new InventoryM();
                    }
                    else if (playerInput == "p" || playerInput == "player" || playerInput == "show player")
                    {
                        ShowPlayer();
                    }
                    else if (playerInput == "o" || playerInput == "options")
                    {
                        //OptionsMenu();
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

            }
            
            /// <summary>
            /// Check if in the current location there are NPCs
            /// </summary>
            /// <param name="newLocation">Ref to the location of the player</param>
            public static void NPCLivingHereChecker(Location newLocation)
            {
                if (newLocation.NpcLivingHere != null)
                {
                    Console.WriteLine("NPC available to talk: " + newLocation.NpcLivingHere.Name);
                }
                else
                {
                    Console.WriteLine("There are no npc to talk here! How sad is it?");
                }
            }

            /// <summary>
            /// Check if in the current location there are Monsters
            /// </summary>
            /// <param name="newLocation">Ref to the location of the player</param>
            public static void MonsterLivingHereChecker(Location newLocation)
            {
                if (newLocation.MonsterLivingHere != null)
                {
                    Console.WriteLine("Monster in this location: " + newLocation.MonsterLivingHere.Name);
                }
                else
                {
                    Console.WriteLine("There are no monsters in this location.");
                }
            }

            /// <summary>
            /// Check if in the current location are available quests
            /// </summary>
            /// <param name="newLocation">Ref to the location of the player</param>
            private static void QuestChecker(Location newLocation)
            {
                if (newLocation.QuestAvailableHere != null)
                {
                    bool playerAlreadyHasQuest = false;
                    bool playerAlreadyCompletedQuest = false;

                    foreach (PlayerQuest playerQuest in _character.newPlayer.Quests)
                    {
                        if (playerQuest.Details.ID == newLocation.QuestAvailableHere.ID)
                        {
                            playerAlreadyHasQuest = true;

                            if (playerQuest.IsCompleted)
                            {
                                if(playerQuest.IsCompleted && playerQuest.Details.ID == 3)
                                {
                                    Console.WriteLine(gameOverText);
                                    return;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine(miniDungeonText);
                                    Console.WriteLine();
                                    Console.WriteLine(newLocation.NpcLivingHere.Name);
                                    Console.WriteLine();
                                    Console.WriteLine(newLocation.NpcLivingHere.Dialogue);
                                    Console.WriteLine();
                                    Console.Write("[Enter] to go back...");
                                    Console.ReadKey();
                                    playerAlreadyCompletedQuest = true; 
                                }
                            }



                        }
                    }
                    PlayerAlreadyHasQuest(newLocation, playerAlreadyHasQuest, playerAlreadyCompletedQuest);

                }
                else
                {
                    //_ = new ShopM();
                }
            }

            /// <summary>
            /// Check if the player already accepted the quest and, if the player has the item/s in their inventory 
            /// the quest is completed
            /// </summary>
            /// <param name="newLocation">Ref to current location of the player</param>
            /// <param name="playerAlreadyHasQuest"></param>
            /// <param name="playerAlreadyCompletedQuest"></param>
            private static void PlayerAlreadyHasQuest(Location newLocation, bool playerAlreadyHasQuest, bool playerAlreadyCompletedQuest)
            {
                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = true;

                        foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            int itemsCount = 0;
                            foreach (InventoryItem ii in _character.newPlayer.Inventory)
                            {
                                if (ii.Details.ID == qci.Details.ID)
                                {
                                    itemsCount += ii.Quantity;
                                }
                            }

                            bool foundItemInPlayersInventory = itemsCount >= qci.Quantity;
                            if (!foundItemInPlayersInventory)
                            {
                                playerHasAllItemsToCompleteQuest = false;
                                break;
                            }
                        }


                        if (playerHasAllItemsToCompleteQuest)
                        {
                            QuestCompleted(newLocation);

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(miniDungeonText);
                            Console.WriteLine();

                            Console.WriteLine(newLocation.NpcLivingHere.QuestNotCompleted);
                            Console.Write("[ENTER] to go back...");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    AcceptedQuest(newLocation);
                }
            }

            /// <summary>
            /// This method is giving the reward to the player after that the quest has been completed
            /// </summary>
            /// <param name="newLocation">Current Location </param>
            private static void QuestCompleted(Location newLocation)
            {
                Console.Clear();
                Console.WriteLine(miniDungeonText);
                Console.WriteLine("*** QUEST ***");
                Console.WriteLine(" " + newLocation.QuestAvailableHere.Name + " => COMPLETED ");
                Console.WriteLine("<==================================================================>");
                Console.WriteLine(newLocation.NpcLivingHere.CompletedQuestDialogue);

                foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                {
                    foreach (InventoryItem ii in _character.newPlayer.Inventory)
                    {
                        if (ii.Details.ID == qci.Details.ID)
                        {
                            ii.Quantity -= qci.Quantity;
                            break;
                        }
                    }
                }

                Console.WriteLine();

                Console.WriteLine("You receive");
                Console.WriteLine("XP: " + newLocation.QuestAvailableHere.RewardExperiencePoints.ToString());
                Console.WriteLine("Gold: " + newLocation.QuestAvailableHere.RewardGold.ToString());
                Console.WriteLine("Item: " + newLocation.QuestAvailableHere.RewardItem.Name);
                Console.WriteLine();

                _character.newPlayer.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));

                RemoveItemsCompletedQuest(_character.newPlayer.Inventory, newLocation.QuestAvailableHere.QuestCompletionItems);

                AddWeaponsToWeaponList(_weapons);
                AddArmorsToArmorList(_armors);
                AddHealingPotionsToHealingPotionList(_healingPotions);

                RemoveWeaponsFromPlayerInventory();
                RemoveArmorsFromPlayerInventory();
                RemoveHealingPotionsFromPlayerInventory();

                for (int i = 0; i < _character.newPlayer.Inventory.Count; i++)

                {

                    foreach (PlayerQuest pq in _character.newPlayer.Quests)
                    {
                        if (pq.Details.ID == newLocation.QuestAvailableHere.ID)
                        {
                            pq.IsCompleted = true;

                            break;
                        }
                    }
                }
                Console.Write("[ENTER] to continue...");
                Console.ReadKey();
            }

            /// <summary>
            /// Removes the quest item/s from player inventory
            /// </summary>
            /// <param name="inventoryItem">Ref to the inventory item</param>
            /// <param name="questCompletionItems">Ref to the item/s required to complete the quest</param>
            private static void RemoveItemsCompletedQuest(List<InventoryItem> inventoryItem, List<QuestCompletionItem> questCompletionItems)
            {
                for (int i = 0; i < inventoryItem.Count; i++)
                {
                    foreach (QuestCompletionItem qci in questCompletionItems)
                    {
                        InventoryItem ii = inventoryItem[i];
                        if (ii.Details.ID == qci.Details.ID)
                        {
                            _character.newPlayer.Inventory.Remove(ii);
                        }

                    }
                }
            }

            /// <summary>
            /// This method is giving the player a summary of the accepted quest 
            /// </summary>
            /// <param name="newLocation">Current location of the player</param>
            private static void AcceptedQuest(Location newLocation)
            {
                TalkToNpc(newLocation);
                Console.Clear();
                Console.WriteLine(miniDungeonText);
                Console.WriteLine();
                Console.WriteLine("*** QUEST INFO ***");
                Console.WriteLine();
                Console.WriteLine("<==================================================================>");
                Console.WriteLine("You receive the `" + newLocation.QuestAvailableHere.Name + "` quest.");
                Console.WriteLine();
                Console.WriteLine(newLocation.QuestAvailableHere.Description);
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("To complete it, return with: ");

                foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                {
                    if (qci.Quantity == 1)
                    {
                        Console.WriteLine("=> " + qci.Quantity.ToString() + " " + qci.Details.Name);
                        Console.WriteLine("<==================================================================>");
                        Console.WriteLine();
                        Console.Write("[Enter] to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("=> " + qci.Quantity.ToString() + " " + qci.Details.NamePlural);
                        Console.WriteLine("<==================================================================>");
                        Console.WriteLine();
                        Console.Write("[Enter] to continue...");
                        Console.ReadKey();
                    }
                }
                Console.WriteLine();

                _character.newPlayer.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
            }

            /// <summary>
            /// Talk with an NPC and in case there a quest available the player can accept or not
            /// </summary>
            /// <param name="newLocation"></param>
            public static void TalkToNpc(Location newLocation)
            {
                string playerInput;

                if (newLocation.NpcLivingHere != null)
                {
                    Console.Clear();
                    Console.WriteLine(miniDungeonText);
                    Console.WriteLine();
                    Console.WriteLine(newLocation.NpcLivingHere.Name);
                    Console.WriteLine("<---------------------------------------------------------------------->");
                    Console.WriteLine(newLocation.NpcLivingHere.QuestDialogue);
                    Console.WriteLine("<---------------------------------------------------------------------->");
                    Console.WriteLine("Accept the quest? y/n");
                    Console.Write(":> ");
                    playerInput = Console.ReadLine().ToLower();

                    if (playerInput == "y" || playerInput == "yes")
                    {
                        return;
                    }
                    else if (playerInput == "n" || playerInput == "no")
                    {
                        return;
                    }
                    else
                    {
                        InvalidInput();
                    }
                }
            }

            static void DrinkHealingPotion()
            {
                int playerInput = 0;

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
                        if (_character.newPlayer.CurrentHitPoints > _character.newPlayer.MaximumHitPoints)
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
        }
    }
}

