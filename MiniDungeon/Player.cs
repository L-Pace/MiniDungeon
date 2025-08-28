using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Enum Player Race
    /// </summary>
    public enum PlayerRace
    {
        Human = 1,
        Elf,
        Dwarf,
        Orc
    }

    /// <summary>
    /// Enum Player Class
    /// </summary>
    public enum PlayerClass
    {
        Warrior = 1,
        Mage,
        Paladin,
        Bard
    }

    /// <summary>
    /// Class Player
    /// </summary>
    public class Player : LifeForm
    {
        public string PlayerName { get;  set; }

        public  PlayerRace playerRace { get; set; }

        public PlayerClass playerClass { get; set; }

        public string CurrentWeapon { get; set; }

        public string CurrentArmor { get; set; }

        public int ClassMinimumDamage { get; set; }
        public int ClassMaximumDamage { get; set; }
        public int ClassMinimumProtection { get; set; }
        public int ClassMaximumProtection { get; set; }

        public float Gold{ get; set; }

        public int ExperiencePoints { get; set; }

        public int Level { get; set; }

        public Location CurrentLocation { get; set; }

        public List<InventoryItem> Inventory { get; set; }

        public List<PlayerQuest> Quests { get; set; }

        /// <summary>
        /// Constructor of Player Class
        /// </summary>
        /// <param name="currentHitPoints">Current HP</param>
        /// <param name="maximumHitPoints">Max HP</param>
        /// <param name="minimumDamage">Minimum Damage with weapon stats applied</param>
        /// <param name="maximumDamage">Maximum Damage with weapon stats applied</param>
        /// <param name="minimumProtection">Minimum Protection with armor stats applied</param>
        /// <param name="maximumProtection">Minimum Damage with weapon stats applied</param>
        /// <param name="currentWeapon">Current Weapon equipped</param>
        /// <param name="currentArmor">Current Armor equipped</param>
        /// <param name="classMinimumDamage">Base Minimum Damage with no weapon equipped</param>
        /// <param name="classMaximumDamage">Base Maximum Damage with no weapon equipped</param>
        /// <param name="classMinimumProtection">Base Minimum Damage</param>
        /// <param name="classMaximumProtection">Base Maximum Damage</param>
        /// <param name="gold">Money bag of the player</param>
        /// <param name="experiencePoints">Current exprience points</param>
        /// <param name="level"></param>
        public Player(int currentHitPoints,
                      int maximumHitPoints,
                      int minimumDamage,
                      int maximumDamage,
                      int minimumProtection,
                      int maximumProtection,
                      string currentWeapon,
                      string currentArmor,
                      int classMinimumDamage,
                      int classMaximumDamage,
                      int classMinimumProtection,
                      int classMaximumProtection,
                      float gold,
                      int experiencePoints,
                      int level
                      ) : base(minimumDamage,maximumDamage,minimumProtection,maximumProtection,currentHitPoints, maximumHitPoints)
        {
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();

            CurrentWeapon = currentWeapon;
            CurrentArmor = currentArmor;
            ClassMinimumDamage = classMinimumDamage;
            ClassMaximumDamage = classMaximumDamage;
            ClassMinimumProtection = classMinimumProtection;
            ClassMaximumProtection = classMaximumProtection;
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;
        }

        
    }
}
