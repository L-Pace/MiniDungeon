using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
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

        public const int ITEM_ID_HEALING_POTION = 13;

        public const int ITEM_ID_GOBLIN_EAR = 11;
        public const int ITEM_ID_TROLL_EYE = 12;

        public const int ITEM_ID_OLIVER_PONYTAIL = 14;
        public const int ITEM_ID_OLIVER_BRAIN = 15;

        public const int ITEM_ID_LUKE_BEARD = 16;
        public const int ITEM_ID_LUKE_MASK = 17;

        public const int ITEM_ID_VIKTOR_GLASSES = 18;
        public const int ITEM_ID_VIKTOR_DOUBLE_MASK = 19;
        public const int ITEM_ID_VIKTOR_GAMEPASS = 20;
        public const int ITEM_ID_VIKTOR_BROKEN_TOE = 21;
        public const int ITEM_ID_MINI_DUNGEON_ENTRANCE_KEY = 22;
        public const int ITEM_ID_MINI_DUNGEON_BOSS_DOOR = 23;
        public const int ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY = 24;


        public const int MONSTER_ID_GOBLIN = 1;
        public const int MONSTER_ID_TROLL = 2;
        public const int MONSTER_ID_OLIVER = 3;
        public const int MONSTER_ID_LUKE = 4;
        public const int MONSTER_ID_VIKTOR = 5;

        public const int QUEST_ID_KILL_THE_GOBLIN = 1;
        public const int QUEST_ID_TALK_WITH_THE_TROLL = 2;
        public const int QUEST_ID_KILL_VIKTOR = 3;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_CAMBRIDGE_TOWN = 2;
        public const int LOCATION_ID_THE_ANTIQUE_SHOP = 3;
        public const int LOCATION_ID_THE_WHITE_HORSE_TAVERN = 4;
        public const int LOCATION_ID_THE_RED_FOREST = 5;
        public const int LOCATION_ID_THE_CABIN_IN_THE_WOODS = 6;
        public const int LOCATION_ID_THE_RED_LAKE = 7;
        public const int LOCATION_ID_MINI_DUNGEON_ENTRANCE = 8;
        public const int LOCATION_ID_MINI_DUNGEON_FIRST_ROOM = 9;
        public const int LOCATION_ID_MINI_DUNGEON_SECOND_ROOM = 10;
        public const int LOCATION_ID_MINI_DUNGEON_THIRD_ROOM = 11;
        public const int LOCATION_ID_MINI_DUNGEON_FOURTH_ROOM = 12;
        public const int LOCATION_ID_MINI_DUNGEON_FIFTH_ROOM= 13;
        public const int LOCATION_ID_COMPASS_HOUSE = 14;


        static World()
        {
            PopulateItems();
            PopulateMonsters();
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

            Items.Add(new Item(ITEM_ID_GOBLIN_EAR, "Globlin Ear", "Globlin Ears", 1));
            Items.Add(new Item(ITEM_ID_TROLL_EYE, "Troll Eye", "Troll Eyes", 2));

            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 2.0f, 5));

            Items.Add(new Item(ITEM_ID_LUKE_BEARD, "Luke Beard", null, 40.0f));
            Items.Add(new Item(ITEM_ID_LUKE_MASK, "Luke Mask", null, 80.0f));

            Items.Add(new Item(ITEM_ID_OLIVER_PONYTAIL, "Oliver Ponytail", null, 45.0f));
            Items.Add(new Item(ITEM_ID_OLIVER_BRAIN, "Oliver Brain", null, 85.0f));

            Items.Add(new Item(ITEM_ID_VIKTOR_GLASSES, "Viktor Glasses", null, 60.0f));
            Items.Add(new Item(ITEM_ID_VIKTOR_DOUBLE_MASK, "Viktor Double Mask", null, 100.0f));
            Items.Add(new Item(ITEM_ID_VIKTOR_GLASSES, "Viktor GamePass", null, 150.0f));
            Items.Add(new Item(ITEM_ID_VIKTOR_BROKEN_TOE, "Viktor Broken Toe", null, 200));

            Items.Add(new Item(ITEM_ID_MINI_DUNGEON_ENTRANCE_KEY, "Dungeon Entrance key", null, 50.0f));
            Items.Add(new Item(ITEM_ID_MINI_DUNGEON_BOSS_DOOR, "Dungeon Boss Door", null, 0));
            Items.Add(new Item(ITEM_ID_THE_CABIN_IN_THE_WOODS_KEY, "The Cabin in the Woods Key", null, 0));
            
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

            Monster luke = new Monster(MONSTER_ID_LUKE, "Luke The Gentle Giant", 8, 8, 6, 25, 7, 7);
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOBLIN_EAR), 75, true));
            luke.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LUKE_MASK), 25, false));

            Monster viktor = new Monster(MONSTER_ID_VIKTOR, "Viktor One Foot", 10, 15, 10, 300, 15, 15);
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_GLASSES), 75, true));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_DOUBLE_MASK), 75, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_GAMEPASS), 25, false));
            viktor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_VIKTOR_BROKEN_TOE), 75, true));
        }


        private static void PopulateQuests()
        {
            throw new NotImplementedException();
        }

        private static void PopulateLocations()
        {
            throw new NotImplementedException();
        }

        private static Item ItemByID(int id)
        {
            foreach(Item item in Items)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
