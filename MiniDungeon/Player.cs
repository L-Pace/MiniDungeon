using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{

    public enum PlayerRace
    {
        Human = 1,
        Elf,
        Dwarf,
        Orc
    }

    public enum PlayerClass
    {
        Warrior = 1,
        Mage,
        Paladin,
        Bard
    }

    public class Player : LifeForm
    {
        public string PlayerName { get;  set; }

        public  PlayerRace playerRace { get; set; }

        public PlayerClass playerClass { get; set; }

        public int MinimumDamage { get; set; }

        public int MinimumProtection { get; set; }

        public float Gold{ get; set; }

        public int ExperiencePoints { get; set; }

        public int Level { get; set; }

        public Location CurrentLocation { get; set; }

        public List<InventoryItem> Inventory { get; set; }

        public List<PlayerQuest> Quests { get; set; }


        public Player(int currentHitPoints,
                      int maximumHitPoints,
                      int minimumDamage,
                      int maximumDamage,
                      int minimumProtection,
                      int maximumProtection,
                      float gold,
                      int experiencePoints,
                      int level
                      ) : base(maximumDamage,maximumProtection,currentHitPoints, maximumHitPoints)
        {
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();

            MinimumDamage = minimumDamage;  
            MinimumProtection = minimumProtection;

            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;
        }

        
    }
}
