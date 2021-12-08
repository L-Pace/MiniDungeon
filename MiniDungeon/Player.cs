using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{

    enum PlayerRace
    {
        Human = 1,
        Elf,
        Dwarf,
        Orc
    }

    enum PlayerClass
    {
        Warrior = 1,
        Mage,
        Paladin,
        Bard
    }

    class Player : LifeForm
    {
        public string PlayerName { get;  set; }

        public  PlayerRace playerRace { get; set; }

        public PlayerClass playerClass { get; set; }

        public float Gold{ get; set; }

        public int ExperiencePoints { get; set; }

        public int Level { get; set; }

        public List<InventoryItem> Inventory { get; set; }

        public List<PlayerQuest> Quests { get; set; }


        public Player(int currentHitPoints, int maximumHitPoints, float gold, int experiencePoints, int level) : base(currentHitPoints, maximumHitPoints)
        {
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();

            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;
        }

    }
}
