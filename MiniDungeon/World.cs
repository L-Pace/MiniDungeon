using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<NPC> NPCs = new List<NPC>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();


        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_THE_MIGHTY_SWORD_OF_THE_VOID = 2;
        public const int ITEM_ID_THE_WAND_OF_FIRE = 3;
        public const int ITEM_ID_THE_HAMMER_OF_SUNSHINE = 4;
        public const int ITEM_ID_THE_GUITAR_SLAYER = 5;
        public const int ITEM_ID_CLUB = 6;


        public const int ITEM_ID_THE_CHESTPLATE_OF_THE_VOID = 7;
        public const int ITEM_ID_THE_ROBE_OF_THE_HOPELESS = 8;
        public const int ITEM_ID_THE_CHESTPLATE_OF_SUNSHINE = 9;
        public const int ITEM_ID_THE_LIGHT_CHESTPLATE_OF_CATARINA = 10;


        public const int ITEM_ID_GOBLIN_EAR = 11;
        public const int ITEM_ID_TROLL_EYE = 12;

        public const int ITEM_ID_HEALING_POTION = 13;

        public const int ITEM_ID_OLIVER_PONYTAIL = 14;
        public const int ITEM_ID_OLIVER_BRAIN = 15;

        public const int ITEM_ID_LUKE_BEARD = 16;
        public const int ITEM_ID_LUKE_MASK = 17;

        public const int ITEM_ID_VIKTOR_GLASSES = 18;
        public const int ITEM_ID_VIKTOR_DOUBLE_MASK = 19;
        public const int ITEM_ID_VIKTOR_GAMEPASS = 20;
        public const int ITEM_ID_VIKTOR_BROKEN_TOE = 21;
        public const int ITEM_ID_MINI_DUNGEON_KEY = 22;
        public const int ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY = 23;
        public const int ITEM_ID_THE_NEW_WORLD_CROWN = 24;
        public const int ITEM_ID_THRONE_ROOM_KEY = 25;


        public const int MONSTER_ID_GOBLIN = 1;
        public const int MONSTER_ID_TROLL = 2;
        public const int MONSTER_ID_OLIVER = 3;
        public const int MONSTER_ID_LUKE = 4;
        public const int MONSTER_ID_VIKTOR = 5;

        public const int NPC_ID_IAN = 1;
        public const int NPC_ID_INNKEEPER = 2;
        public const int NPC_ID_THE_HERMIT_IN_THE_WOODS = 3;

        public const int QUEST_ID_CLEAR_THE_FOREST = 1;
        public const int QUEST_ID_ANTIDODE = 2;
        public const int QUEST_ID_KILL_VIKTOR = 3;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_COMPASS_HOUSE = 2;
        public const int LOCATION_ID_THE_NERD_SHRINE = 3;
        public const int LOCATION_ID_THE_WHITE_HORSE_TAVERN = 4;
        public const int LOCATION_ID_IAN_HOUSE = 5;
        public const int LOCATION_ID_THE_RED_FOREST = 6;
        public const int LOCATION_ID_THE_CABIN_IN_THE_WOODS = 7;
        public const int LOCATION_ID_THE_RED_LAKE = 8;
        public const int LOCATION_ID_MINI_DUNGEON_ENTRANCE = 9;
        public const int LOCATION_ID_MINI_DUNGEON_FIRST_ROOM = 10;
        public const int LOCATION_ID_MINI_DUNGEON_SECOND_ROOM = 11;
        public const int LOCATION_ID_MINI_DUNGEON_THIRD_ROOM = 12;
        public const int LOCATION_ID_MINI_DUNGEON_THRONE_ROOM = 13;




        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateNPC();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty sword", "Rusty Swords", 2.0f, 0, 5));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 2.0f, 0, 7));

            Items.Add(new Weapon(ITEM_ID_THE_MIGHTY_SWORD_OF_THE_VOID, "The Mighty Sword of the Void", "The Maighty Swords of the Void", 50, 2, 10));
            Items.Add(new Weapon(ITEM_ID_THE_WAND_OF_FIRE, "The Wand of Fire", "The Wands of Fire", 5.0f, 2, 10));
            Items.Add(new Weapon(ITEM_ID_THE_HAMMER_OF_SUNSHINE, "The Hammer of Sunshine", "The Hammers of Sunshine", 5.0f, 2, 10));
            Items.Add(new Weapon(ITEM_ID_THE_GUITAR_SLAYER, "The Guitar Slayer", "The Guitars Slayer", 5.0f, 2, 10));

            Items.Add(new Armor(ITEM_ID_THE_CHESTPLATE_OF_THE_VOID, "Chestplate of the Void", "Chestplates of the Void", 5.0f, 2, 5));
            Items.Add(new Armor(ITEM_ID_THE_ROBE_OF_THE_HOPELESS, "The Robe of the Hopeless", "The Robes of the Hopeless", 5.0f, 1, 4));
            Items.Add(new Armor(ITEM_ID_THE_CHESTPLATE_OF_SUNSHINE, "Chestplate of the Sunshine", "Chestplates of the Sunshine", 5.0f, 2, 5));
            Items.Add(new Armor(ITEM_ID_THE_LIGHT_CHESTPLATE_OF_CATARINA, "Light Chestplate of Catarina", "Light Chestplates of Catarina", 5.0f, 2, 5));

            Items.Add(new Item(ITEM_ID_GOBLIN_EAR, "Globlin Ear", "Globlin Ears", 1.0f));
            Items.Add(new Item(ITEM_ID_TROLL_EYE, "Troll Eye", "Troll Eyes", 2.0f));
            Items.Add(new Item(ITEM_ID_THE_NEW_WORLD_CROWN, "New World Crown", null, 0));

            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 2.0f, 5));

            Items.Add(new Item(ITEM_ID_LUKE_BEARD, "Luke Beard", null, 40.0f));
            Items.Add(new Item(ITEM_ID_LUKE_MASK, "Luke Mask", null, 80.0f));

            Items.Add(new Item(ITEM_ID_OLIVER_PONYTAIL, "Oliver Ponytail", null, 45.0f));
            Items.Add(new Item(ITEM_ID_OLIVER_BRAIN, "Oliver Brain", null, 85.0f));

            Items.Add(new Item(ITEM_ID_VIKTOR_GLASSES, "Viktor Glasses", null, 60.0f));
            Items.Add(new Item(ITEM_ID_VIKTOR_DOUBLE_MASK, "Viktor Double Mask", null, 100.0f));
            Items.Add(new Item(ITEM_ID_VIKTOR_GLASSES, "Viktor GamePass", null, 150.0f));
            Items.Add(new Item(ITEM_ID_VIKTOR_BROKEN_TOE, "Viktor Broken Toe", null, 200));

            Items.Add(new Item(ITEM_ID_MINI_DUNGEON_KEY, "Dungeon key", null, 50.0f));
            Items.Add(new Item(ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY, "The Cabin in the Woods Key", null, 0));
            Items.Add(new Item(ITEM_ID_THRONE_ROOM_KEY, "The Throne Room Key", null, 0));

        }

        private static void PopulateMonsters()
        {
            Monster goblin = new Monster(MONSTER_ID_GOBLIN, "Goblin", 5, 5, 3, 10, 3, 3);
            goblin.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOBLIN_EAR), 75, true));
            goblin.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUSTY_SWORD), 75, false));

            Monster troll = new Monster(MONSTER_ID_TROLL, "Troll", 6, 6, 4, 15, 4, 4);
            troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TROLL_EYE), 75, true));
            troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CLUB), 75, false));

            Monster oliver = new Monster(MONSTER_ID_OLIVER, "Oliver the Chosen One", 7, 7, 5, 20, 5, 5);
            oliver.LootTable.Add(new LootItem(ItemByID(ITEM_ID_OLIVER_PONYTAIL), 75, true));
            oliver.LootTable.Add(new LootItem(ItemByID(ITEM_ID_OLIVER_BRAIN), 25, false));
            oliver.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THRONE_ROOM_KEY), 100, true));

            Monster luke = new Monster(MONSTER_ID_LUKE, "Luke The Gentle Giant", 8, 8, 6, 25, 7, 7);
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LUKE_BEARD), 75, true));
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LUKE_MASK), 25, false));
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MINI_DUNGEON_KEY), 100, true));

            Monster viktor = new Monster(MONSTER_ID_VIKTOR, "Viktor One Foot", 10, 15, 10, 300, 15, 15);
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_GLASSES), 75, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_DOUBLE_MASK), 75, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_GAMEPASS), 25, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_BROKEN_TOE), 75, true));

            Monsters.Add(goblin);
            Monsters.Add(troll);
            Monsters.Add(oliver);
            Monsters.Add(luke);
            Monsters.Add(viktor);
        }

        private static void PopulateNPC()
        {
            NPC ian = new NPC(NPC_ID_IAN, "Ian, the Alchemist", " Hello traveler. I'm Ian, the Alchemist.\n I have a job for ya. I'm preparing an antidote for my dog that by\n accident ate snake chocolate.\n I can't leave home right now and I need `3 trolls eye` to complete the\n antidote.\n I saw some trolls just around the Red Lake.\n If you'll help me I'll give you the `key` that open the `Cabin in the\n woods`, just South of the Red Forest and 20 gold.", "I need the ingredients ASAP or my dog will make a mess for at least 3 days in a row!", " Thank you for your help!\n This is your reward and good luck for your adventure!", "I'm quite busy preparing the antidote for my dog! Thank you again for your help! See you around!");

            NPC innkeeper = new NPC(NPC_ID_INNKEEPER, " James, the innkeeper", " Are you looking for a job? Fine...Kill the goblins that infesting the\n Red Forest\n and bring back `3 goblins ears`.\n I'll give you an healing potion and, of course, 15 golds!", "The goblins are still alive? I think it's not a big deal kill\n some annoying goblins, right? Come back with the ears!", "Hope the goblins didn't give you hard time! This is your reward!", "All day cleaning already clean glasses. What's the point to have a business in this town?\n FOR THE GLORY!!\n [A glass crash in his hands] I need a medic...");

            NPC hermit = new NPC(NPC_ID_THE_HERMIT_IN_THE_WOODS, "Dominuque, the hermit in the woods", " Hello Traveler.\n The situation inside of Mini Dungeon is getting worse day by day.\n Viktor One Foot is sitting on the throne inside of the last room of\n the dungeon and his command is to take over of our amazing city:\n Compass House.\n Unfortunately the dungeon's infested by goblins, trolls and 2 Viktor's\n guard: `Oliver The Chosen One` and `Luke The Gentle Giant`.\n He needs to be stopped ASAP to finally create our `New World`.\n Bring me Viktor's `toe`.\n Let's say that I'll give you 500 gold for the `toe` and..... you'll\n see! Good Luck!!", " Where is Viktor's toe? Still on his foot? Go back in the Mini Dungeon and defeat him!!!", "Congratulation my new Lord! Now we'll rebuild our new world! The Mini Dungeon is now in our hands and you'll be my muppet! Now you're in my dominion! Death and diseases will be upon Compass House, Cambridge Town and all the lands surrounding us.........ehm of course I'm joking. We'll refubrish the Mini Dungeon and we'll open again the museum.", "Dominique disappeared and he left this message:\n `I'm away for holidays in New Castle`. I'll be back in few years!");

            NPCs.Add(ian);
            NPCs.Add(innkeeper);
            NPCs.Add(hermit);
            
        } 

        private static void PopulateQuests()
        {
            Quest clearTheForest = new Quest(
                QUEST_ID_CLEAR_THE_FOREST,
                " Goblin Genocide",
                " The innkeeper in town needs help to clear the Red forest from the\ngoblins.", 20, 15);

            clearTheForest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_GOBLIN_EAR), 3));
            clearTheForest.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Quest antidote = new Quest(
                QUEST_ID_ANTIDODE,
                " The Eye of Madness",
                " Ian, The alchemist, asked me to help him with antidote for his dog.", 20, 20);

            antidote.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_TROLL_EYE), 3));
            antidote.RewardItem = ItemByID(ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY);

            Quest killViktor = new Quest(
                QUEST_ID_KILL_VIKTOR,
                " Kill Viktor One Foot",
                " The hermit asked me to kill Viktor that is located in the last\n room inside of Mini Dungeon.", 50, 500);

            killViktor.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_VIKTOR_BROKEN_TOE), 1));
            killViktor.RewardItem = ItemByID(ITEM_ID_THE_NEW_WORLD_CROWN);

            Quests.Add(clearTheForest);
            Quests.Add(antidote);
            Quests.Add(killViktor);
        }

        private static void PopulateLocations()
        {
            Location home = new Location(LOCATION_ID_HOME, "Home", "This is your home. Not the best place ever where\n you can sleep well but, at least, you got a roof\n above your head.");

            Location compassHouse = new Location(LOCATION_ID_COMPASS_HOUSE, "Compass House Town", "Our majestic town made by nerds without social\n life. People like to spend most of their time\n programming and eating crisps Tyrell (cheese and\n onions).\n You can still smell the ash produced by our evil\n lord during the last session of Applied Science\n for Games!");

            Location theWhiteHorseTavern = new Location(LOCATION_ID_THE_WHITE_HORSE_TAVERN, "The White Horse Tavern", "There is a guy waiting at the counter, cleanig\n really shiny and already clean glasses.\n Quite empty for all day.\n Probably people in town are not interested to\n drink a pint of finest `dirty water`. Ah yeah,\n nerds life!");
            theWhiteHorseTavern.NpcLivingHere = NPCbyID(NPC_ID_INNKEEPER);
            theWhiteHorseTavern.QuestAvailableHere = QuestbyID(QUEST_ID_CLEAR_THE_FOREST);

            Location redForest = new Location(LOCATION_ID_THE_RED_FOREST, "The Red Forest", "In the moment that you stepped in this forest,\n from far away, you can hear goblins screaming\n and swearing.");
            redForest.MonsterLivingHere = MonsterByID(MONSTER_ID_GOBLIN);

            Location ianHouse = new Location(LOCATION_ID_IAN_HOUSE, "Ian, The Alchemist, house", "This amazing house is made by thousends of\n boardgames in limited edition. You can see even\n a Settles of Catan made by gold with a signature:\n from Viktor");
            ianHouse.NpcLivingHere = NPCbyID(NPC_ID_IAN);
            ianHouse.QuestAvailableHere = QuestbyID(QUEST_ID_ANTIDODE);

            Location redLake = new Location(LOCATION_ID_THE_RED_LAKE, "The Red Lake", "An amazing lake full of life! Dangerous place\n without any armor!!");
            redLake.MonsterLivingHere = MonsterByID(MONSTER_ID_TROLL);

            Location nerdShrine = new Location(LOCATION_ID_THE_NERD_SHRINE, "The Nerd Shrine", "The amazing (only) pricey shop in town.\n You can smell the sweat after a 3 days session of\n Mini Dungeons and Wyverns");

            Location theCabinInTheWoods = new Location(LOCATION_ID_THE_CABIN_IN_THE_WOODS, "The Cabin in the Woods", "Mysterious cabin in the middle of nowhere.\n Sorrounded by dead trees and a strange timeless\n fog.", ItemByID(ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY));
            theCabinInTheWoods.NpcLivingHere = NPCbyID(NPC_ID_THE_HERMIT_IN_THE_WOODS);
            theCabinInTheWoods.QuestAvailableHere = QuestbyID(QUEST_ID_KILL_VIKTOR);

            Location miniDungeonEntrance = new Location(LOCATION_ID_MINI_DUNGEON_ENTRANCE, "Mini Dungeon Entrance", "The entrance of the Mini Dungeon with a gold\n plated door");
            miniDungeonEntrance.MonsterLivingHere = MonsterByID(MONSTER_ID_LUKE);

            Location miniDungeonFirstRoom = new Location(LOCATION_ID_MINI_DUNGEON_FIRST_ROOM, "First Mini Dungeon Room", "Quite dark room without windows.\n You can see something moving in the darkness and\n you can hear .... a fart(?). From the smell is a\n goblin for sure with some sirious belly problems.\n Are Ian dog and this goblin related?", ItemByID(ITEM_ID_MINI_DUNGEON_KEY));
            miniDungeonFirstRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_GOBLIN);

            Location miniDungeonSecondRoom = new Location(LOCATION_ID_MINI_DUNGEON_SECOND_ROOM, "Second Mini Dungeon Room", "Dark as the previous one. Strange sounds in the\n darkness again!");
            miniDungeonSecondRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_TROLL);

            Location miniDungeonThirdRoom = new Location(LOCATION_ID_MINI_DUNGEON_THIRD_ROOM, "Third Mini Dungeon Room", "This room smells different. You can hear somebody\n screming WAKA WAKA WAKA WAKA!");
            miniDungeonThirdRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_OLIVER);

            Location miniDungeonThroneRoom = new Location(LOCATION_ID_MINI_DUNGEON_THRONE_ROOM, "The Throne Room", "The majestic Throne Room where Viktor One Foot\n manage his guild", ItemByID(ITEM_ID_THRONE_ROOM_KEY));
            miniDungeonThroneRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_VIKTOR);

            home.LocationToEast = compassHouse;
            home.LocationToWest = redForest;

            compassHouse.LocationToNorth = nerdShrine;
            compassHouse.LocationToSouth = theWhiteHorseTavern;
            compassHouse.LocationToEast = ianHouse;
            compassHouse.LocationToWest = home;

            theWhiteHorseTavern.LocationToNorth = compassHouse;

            ianHouse.LocationToWest = compassHouse;

            nerdShrine.LocationToSouth = compassHouse;

            redForest.LocationToNorth = miniDungeonEntrance;
            redForest.LocationToSouth = theCabinInTheWoods;
            redForest.LocationToWest = redLake;
            redForest.LocationToEast = home;


            theCabinInTheWoods.LocationToNorth = redForest;

            redLake.LocationToEast = redForest;

            miniDungeonEntrance.LocationToNorth = miniDungeonFirstRoom;
            miniDungeonEntrance.LocationToSouth = redForest;


            miniDungeonFirstRoom.LocationToEast = miniDungeonSecondRoom;
            miniDungeonFirstRoom.LocationToSouth = miniDungeonEntrance;

            miniDungeonSecondRoom.LocationToNorth = miniDungeonThirdRoom;
            miniDungeonSecondRoom.LocationToWest = miniDungeonFirstRoom;

            miniDungeonThirdRoom.LocationToEast = miniDungeonThroneRoom;
            miniDungeonThirdRoom.LocationToSouth = miniDungeonSecondRoom;

            miniDungeonThroneRoom.LocationToWest = miniDungeonThirdRoom;

            Locations.Add(home);
            Locations.Add(compassHouse);
            Locations.Add(ianHouse);
            Locations.Add(nerdShrine);
            Locations.Add(theWhiteHorseTavern);
            Locations.Add(redForest);
            Locations.Add(redLake);
            Locations.Add(miniDungeonEntrance);
            Locations.Add(miniDungeonFirstRoom);
            Locations.Add(miniDungeonSecondRoom);
            Locations.Add(miniDungeonThirdRoom);
            Locations.Add(miniDungeonThroneRoom);
        }

        public static NPC NPCbyID(int id)
        {
            foreach (NPC npc in NPCs)
            {
                if (npc.ID == id)
                {
                    return npc;
                }
            }
            return null; 
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null; ;
        }

        private static Quest QuestbyID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }
            return null; ;
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}