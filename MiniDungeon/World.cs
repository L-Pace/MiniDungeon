using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Weapon> Weapons = new List<Weapon>();
        public static readonly List<Armor> Armors = new List<Armor>();
        public static readonly List<HealingPotion> HealingPotions = new List<HealingPotion>();
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
        public const int ITEM_ID_THE_MIGHTY_WOODEN_STICK = 7;


        public const int ITEM_ID_THE_CHESTPLATE_OF_THE_VOID = 8;
        public const int ITEM_ID_THE_ROBE_OF_THE_HOPELESS = 9;
        public const int ITEM_ID_THE_CHESTPLATE_OF_SUNSHINE = 10;
        public const int ITEM_ID_THE_LIGHT_CHESTPLATE_OF_CATARINA = 11;
        public const int ITEM_ID_THE_MIGHTY_USELESS_CLOTHES = 12;


        public const int ITEM_ID_GOBLIN_EAR = 13;
        public const int ITEM_ID_TROLL_EYE = 14;

        public const int ITEM_ID_HEALING_POTION = 15;

        public const int ITEM_ID_OLIVER_PONYTAIL = 16;
        public const int ITEM_ID_OLIVER_BRAIN = 17;

        public const int ITEM_ID_LUKE_BEARD = 18;
        public const int ITEM_ID_LUKE_MASK = 19;

        public const int ITEM_ID_VIKTOR_GLASSES = 20;
        public const int ITEM_ID_VIKTOR_DOUBLE_MASK = 21;
        public const int ITEM_ID_VIKTOR_GAMEPASS = 22;
        public const int ITEM_ID_VIKTOR_BROKEN_TOE = 23;
        public const int ITEM_ID_MINI_DUNGEON_KEY = 24;
        public const int ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY = 25;
        public const int ITEM_ID_THE_NEW_WORLD_CROWN = 26;
        public const int ITEM_ID_THRONE_ROOM_KEY = 27;

        public const int ITEM_ID_SOURDOUGH_BREAD = 28;
        public const int ITEM_ID_BIG_HEALING_POTION = 29;

        public const int ITEM_ID_THE_SPELLBOOK_OF_REPAIR = 30;

        public const int MONSTER_ID_GOBLIN = 1;
        public const int MONSTER_ID_TROLL = 2;
        public const int MONSTER_ID_OLIVER = 3;
        public const int MONSTER_ID_LUKE = 4;
        public const int MONSTER_ID_VIKTOR = 5;
        public const int MONSTER_ID_KING_GOBLIN = 6;
        public const int MONSTER_ID_KING_TROLL = 7;

        public const int NPC_ID_IAN = 1;
        public const int NPC_ID_INNKEEPER = 2;
        public const int NPC_ID_THE_HERMIT_IN_THE_WOODS = 3;
        public const int NPC_ID_CENK_THE_NERD_SHOPKEEPER = 4;

        public const int QUEST_ID_CLEAR_THE_FOREST = 1;
        public const int QUEST_ID_ANTIDODE = 2;
        public const int QUEST_ID_KILL_VIKTOR = 3;
        public const int QUEST_ID_THE_SPELL_BOOK_OF_REPAIR = 4;

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



        /// <summary>
        /// Main Engine of the game
        /// </summary>
        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateNPC();
            PopulateQuests();
            PopulateLocations();
        }

        /// <summary>
        /// Add to the world all the items 
        /// </summary>
        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty sword", "Rusty Swords", 2.0f, 1, 3));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 2.0f, 1, 5));
            Items.Add(new Weapon(ITEM_ID_THE_MIGHTY_WOODEN_STICK, "The Mighty Wooden Stick", "The Mighty Wooden Stick", 2.0f, 1, 2));

            Items.Add(new Weapon(ITEM_ID_THE_MIGHTY_SWORD_OF_THE_VOID, "The Mighty Sword of the Void", "The Maighty Swords of the Void", 50, 2, 10));
            Items.Add(new Weapon(ITEM_ID_THE_WAND_OF_FIRE, "The Wand of Fire", "The Wands of Fire", 5.0f, 2, 10));
            Items.Add(new Weapon(ITEM_ID_THE_HAMMER_OF_SUNSHINE, "The Hammer of Sunshine", "The Hammers of Sunshine", 5.0f, 2, 10));
            Items.Add(new Weapon(ITEM_ID_THE_GUITAR_SLAYER, "The Guitar Slayer", "The Guitars Slayer", 5.0f, 2, 10));

            Items.Add(new Armor(ITEM_ID_THE_CHESTPLATE_OF_THE_VOID, "Chestplate of the Void", "Chestplates of the Void", 5.0f, 2, 5));
            Items.Add(new Armor(ITEM_ID_THE_ROBE_OF_THE_HOPELESS, "The Robe of the Hopeless", "The Robes of the Hopeless", 5.0f, 1, 4));
            Items.Add(new Armor(ITEM_ID_THE_CHESTPLATE_OF_SUNSHINE, "Chestplate of the Sunshine", "Chestplates of the Sunshine", 5.0f, 2, 5));
            Items.Add(new Armor(ITEM_ID_THE_LIGHT_CHESTPLATE_OF_CATARINA, "Light Chestplate of Catarina", "Light Chestplates of Catarina", 5.0f, 2, 5));
            Items.Add(new Armor(ITEM_ID_THE_MIGHTY_USELESS_CLOTHES, "The Mighty Useless Clothes", "The Mighty Useless Clothes", 2.0f, 0, 2));

            Items.Add(new Item(ITEM_ID_GOBLIN_EAR, "Globlin Ear", "Globlin Ears", 1.0f));
            Items.Add(new Item(ITEM_ID_TROLL_EYE, "Troll Eye", "Troll Eyes", 2.0f));
            Items.Add(new Item(ITEM_ID_THE_NEW_WORLD_CROWN, "New World Crown", null, 0));

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
            Items.Add(new Item(ITEM_ID_THE_SPELLBOOK_OF_REPAIR, "The Spell Book of Repair", null, 0));



            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 5.0f, 5));
            Items.Add(new HealingPotion(ITEM_ID_BIG_HEALING_POTION, "Big Healing Potion", "Big Healing Potions", 10.0f, 10));
            Items.Add(new HealingPotion(ITEM_ID_SOURDOUGH_BREAD, "Sourdough Bread", "Healing Potions", 2.0f, 2));



        }

        /// <summary>
        /// This method is populating all the mosters
        /// </summary>
        private static void PopulateMonsters()
        {
            Monster goblin = new Monster(MONSTER_ID_GOBLIN, "Goblin", 1, 2, 0, 2, 3, 10, 3, 3);
            goblin.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOBLIN_EAR), 75, true));
            goblin.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUSTY_SWORD), 75, false));

            Monster troll = new Monster(MONSTER_ID_TROLL, "Troll", 1, 3, 1, 3, 4, 15, 4, 4);
            troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TROLL_EYE), 75, true));
            troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CLUB), 75, false));

            Monster kingGoblin = new Monster(MONSTER_ID_KING_GOBLIN, "King Goblin", 2, 3, 1, 3, 4, 15, 5, 5);
            kingGoblin.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOBLIN_EAR), 75, true));
            kingGoblin.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_MIGHTY_SWORD_OF_THE_VOID), 75, false));
            kingGoblin.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_CHESTPLATE_OF_THE_VOID), 75, false));

            Monster kingTroll = new Monster(MONSTER_ID_KING_TROLL, "King Troll", 2, 4, 2, 4, 5, 20, 6, 6);
            kingTroll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TROLL_EYE), 75, true));
            kingTroll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_HAMMER_OF_SUNSHINE), 75, false));
            kingTroll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_CHESTPLATE_OF_SUNSHINE), 75, false));
            kingTroll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_SPELLBOOK_OF_REPAIR), 100, true));

            Monster oliver = new Monster(MONSTER_ID_OLIVER, "Oliver the Chosen One", 2, 4, 2, 4, 5, 20, 5, 5);
            oliver.LootTable.Add(new LootItem(ItemByID(ITEM_ID_OLIVER_PONYTAIL), 75, true));
            oliver.LootTable.Add(new LootItem(ItemByID(ITEM_ID_OLIVER_BRAIN), 25, false));
            oliver.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_ROBE_OF_THE_HOPELESS), 75, false));
            oliver.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MINI_DUNGEON_KEY), 100, true));

            Monster luke = new Monster(MONSTER_ID_LUKE, "Luke The Gentle Giant", 3, 5, 3, 6, 6, 25, 7, 7);
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LUKE_BEARD), 100, true));
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LUKE_MASK), 25, false));
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_WAND_OF_FIRE), 75, false));
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THE_LIGHT_CHESTPLATE_OF_CATARINA), 75, false));
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_THRONE_ROOM_KEY), 100, true));

            Monster viktor = new Monster(MONSTER_ID_VIKTOR, "Viktor One Foot", 4, 10, 4, 8, 10, 300, 15, 15);
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_GLASSES), 75, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_DOUBLE_MASK), 75, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_GAMEPASS), 25, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_BROKEN_TOE), 100, true));

            Monsters.Add(goblin);
            Monsters.Add(troll);
            Monsters.Add(kingGoblin);
            Monsters.Add(kingTroll);
            Monsters.Add(oliver);
            Monsters.Add(luke);
            Monsters.Add(viktor);
        }

        /// <summary>
        /// This methos is populating all the NPCs
        /// </summary>
        private static void PopulateNPC()
        {
            NPC ian = new NPC(
                NPC_ID_IAN,
                " Ian, the Alchemist",
                " Hello traveller. I'm Ian, the Alchemist.\n I have a job for ya. I'm preparing an antidote for my dog that by\n accident ate snake chocolate.\n I can't leave home right now and I need `3 trolls eye` to complete the\n antidote.\n I saw some trolls just around the Red Lake.\n If you'll help me I'll give you the `key` that open the `Cabin in the\n woods`, just South of the Red Forest and 20 gold.",
                "I need the ingredients ASAP or my dog will make a mess for at least 3 days in a row!",
                " Thank you for your help!\n This is your reward and good luck for your adventure!",
                "I'm quite busy preparing the antidote for my dog! Thank you again for your help! See you around!");

            NPC innkeeper = new NPC(
                NPC_ID_INNKEEPER,
                " James, the innkeeper",
                " Are you looking for a job? Fine...Kill the goblins that infesting the\n Red Forest\n and bring back `3 goblins ears`.\n I'll give you an healing potion and, of course, 15 golds!",
                "The goblins are still alive? I think it's not a big deal kill\n some annoying goblins, right? Come back with the ears!",
                "Hope the goblins didn't give you hard time! This is your reward!",
                "All day cleaning already clean glasses. What's the point to have a business in this town?\n FOR THE GLORY!!\n [A glass crash in his hands] I need a medic...");

            NPC hermit = new NPC(
                NPC_ID_THE_HERMIT_IN_THE_WOODS,
                " Dominuque, the hermit in the woods",
                " Hello Traveller.\n The situation inside of Mini Dungeon is getting worse day by day.\n Viktor One Foot is sitting on the throne inside of the last room of\n the dungeon and his command is to take over of our amazing city:\n Compass House.\n Unfortunately the dungeon's infested by goblins, trolls and 2 Viktor's\n guard: `Oliver The Chosen One` and `Luke The Gentle Giant`.\n He needs to be stopped ASAP to finally create our `New World`.\n Bring me Viktor's `toe`.\n Let's say that I'll give you 500 gold for the `toe` and..... you'll\n see! Good Luck!!",
                " Where is Viktor's toe? Still on his foot? Go back in the Mini Dungeon and defeat him!!!",
                "Congratulation my new Lord! Now we'll rebuild our new world! The Mini Dungeon is now in our hands and you'll be my muppet! Now you're in my dominion! Death and diseases will be upon Compass House, Cambridge Town and all the lands surrounding us.........ehm of course I'm joking. We'll refubrish the Mini Dungeon and we'll open again the museum.",
                "Dominique disappeared and he left this message:\n `I'm away for holidays in New Castle`. I'll be back in few years!");

            NPC cenk = new NPC(
                NPC_ID_CENK_THE_NERD_SHOPKEEPER,
                " Cenk, the Nerd Shopkeeper",
                " OMG!\n Finally somebody is coming here to help me out.\n The King Troll and The King Goblin raided the shop few days ago.\n They stole everything and trushed the place! I tried to get\n back my staff but, I couldn't defeat the King Troll!\n He was using my stuff! I've seen even regular trolls and goblins\n with armors and weapons from the shop!\n I need you help and in exchange you can keep some of the equipment!\n Bring me back my 'Spell Book of Repair'!",
                " I don't want to make you rush but, without the book it will take\n me a decade to repair everything!",
                " Thank you so much for your help, Traveller",
                " Cenk is repairing the shop! Will open soon!");

            NPCs.Add(ian);
            NPCs.Add(innkeeper);
            NPCs.Add(hermit);
            NPCs.Add(cenk);
            
        } 

        /// <summary>
        /// This method is populating all the quests
        /// </summary>
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

            Quest theSpellBookOfRepair = new Quest(
                QUEST_ID_THE_SPELL_BOOK_OF_REPAIR,
                " Repair never been so easy",
                " Cenk needs the Spell Book of Repair to fix the shop! He mentioned the King Troll in the Mini Dungeon!", 50, 500);

            theSpellBookOfRepair.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_THE_SPELLBOOK_OF_REPAIR), 1));
            theSpellBookOfRepair.RewardItem = ItemByID(ITEM_ID_THE_NEW_WORLD_CROWN);

            Quests.Add(clearTheForest);
            Quests.Add(antidote);
            Quests.Add(killViktor);
            Quests.Add(theSpellBookOfRepair);
        }

        /// <summary>
        /// This method is populating all the locations
        /// </summary>
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

            Location nerdShrine = new Location(LOCATION_ID_THE_NERD_SHRINE, "The Nerd Shrine", "This placed is completely trashed!\n The shopkeeper is sitting on a broken barrel\n and he's smiling at you!");
            nerdShrine.NpcLivingHere = NPCbyID(NPC_ID_CENK_THE_NERD_SHOPKEEPER);
            nerdShrine.QuestAvailableHere = QuestbyID(QUEST_ID_THE_SPELL_BOOK_OF_REPAIR);


            // This is part of the shop that I have not finished to implement, indeed, I commenteded it

            //Vendor cenk = new Vendor("Cenk, the Nerd Shopkeeper");

            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_MIGHTY_SWORD_OF_THE_VOID), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_WAND_OF_FIRE), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_HAMMER_OF_SUNSHINE), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_GUITAR_SLAYER), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_CHESTPLATE_OF_THE_VOID), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_ROBE_OF_THE_HOPELESS), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_CHESTPLATE_OF_SUNSHINE), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_THE_LIGHT_CHESTPLATE_OF_CATARINA), 1);
            //cenk.AddItemToVendorInventory(ItemByID(ITEM_ID_HEALING_POTION), 5);

            //nerdShrine.VendorWorkingHere = cenk;

            Location theCabinInTheWoods = new Location(LOCATION_ID_THE_CABIN_IN_THE_WOODS, "The Cabin in the Woods", "Mysterious cabin in the middle of nowhere.\n Sorrounded by dead trees and a strange timeless\n fog.", ItemByID(ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY));
            theCabinInTheWoods.NpcLivingHere = NPCbyID(NPC_ID_THE_HERMIT_IN_THE_WOODS);
            theCabinInTheWoods.QuestAvailableHere = QuestbyID(QUEST_ID_KILL_VIKTOR);

            Location miniDungeonEntrance = new Location(LOCATION_ID_MINI_DUNGEON_ENTRANCE, "Mini Dungeon Entrance", "The entrance of the Mini Dungeon with a gold\n plated door");
            miniDungeonEntrance.MonsterLivingHere = MonsterByID(MONSTER_ID_OLIVER);

            Location miniDungeonFirstRoom = new Location(LOCATION_ID_MINI_DUNGEON_FIRST_ROOM, "First Mini Dungeon Room", "Quite dark room without windows.\n You can see something moving in the darkness and\n you can hear .... a fart(?). From the smell is a\n goblin for sure with some sirious belly problems.\n Are Ian dog and this goblin related?", ItemByID(ITEM_ID_MINI_DUNGEON_KEY));
            miniDungeonFirstRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_KING_GOBLIN);

            Location miniDungeonSecondRoom = new Location(LOCATION_ID_MINI_DUNGEON_SECOND_ROOM, "Second Mini Dungeon Room", "Dark as the previous one. Strange sounds in the\n darkness again!");
            miniDungeonSecondRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_KING_TROLL);

            Location miniDungeonThirdRoom = new Location(LOCATION_ID_MINI_DUNGEON_THIRD_ROOM, "Third Mini Dungeon Room", "This room smells different. You can hear somebody\n screming!");
            miniDungeonThirdRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_LUKE);

            Location miniDungeonThroneRoom = new Location(LOCATION_ID_MINI_DUNGEON_THRONE_ROOM, "The Throne Room", "The majestic Throne Room where Viktor One Foot\n manage his guild", ItemByID(ITEM_ID_THRONE_ROOM_KEY));
            miniDungeonThroneRoom.MonsterLivingHere = MonsterByID(MONSTER_ID_VIKTOR);

            // All the location connected to each other
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

        /// <summary>
        /// Get the by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the monster by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the quest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the items by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the locations by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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