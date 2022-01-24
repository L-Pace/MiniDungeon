using System;

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

            private static void ExploreMenu()
            {
                string playerInput;
                bool exploreMenuLoop = true;

                Console.Clear();

                while (exploreMenuLoop)
                {
                    Console.WriteLine(miniDungeonText);
                    Console.WriteLine();
                    Console.WriteLine("*** CURRENT LOCATION ***");
                    Console.WriteLine(" => " + _character.newPlayer.CurrentLocation.Name.ToString());
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
                        _ = new EngageFightM();
                    }
                    else if (playerInput == "i" || playerInput == "inventory")
                    {
                        _ = new InventoryM();
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

                    PlayerAlreadyHasQuest(newLocation, playerAlreadyHasQuest, playerAlreadyCompletedQuest);
                }
            }

            private static void PlayerAlreadyHasQuest(Location newLocation, bool playerAlreadyHasQuest, bool playerAlreadyCompletedQuest)
            {
                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = true;

                        foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            bool foundItemInPlayersInventory = false;

                            foreach (InventoryItem ii in _character.newPlayer.Inventory)
                            {
                                if (ii.Details.ID == qci.Details.ID)
                                {
                                    foundItemInPlayersInventory = true;

                                    if (ii.Quantity < qci.Quantity)
                                    {
                                        playerHasAllItemsToCompleteQuest = false;
                                        break;
                                    }
                                    break;
                                }
                            }
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

                bool addedItemToPlayerInventory = false;

                for (int i = 0; i < _character.newPlayer.Inventory.Count; i++)
                {
                    InventoryItem ii = _character.newPlayer.Inventory[i];
                    if (ii.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
                    {
                        ii.Quantity++;

                        addedItemToPlayerInventory = true;
                        break;
                    }

                    if (!addedItemToPlayerInventory)
                    {
                        _character.newPlayer.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));
                    }

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
        }
    }
}

