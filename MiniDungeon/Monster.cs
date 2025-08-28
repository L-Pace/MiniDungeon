using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Monster class 
    /// </summary>
    public class Monster : LifeForm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }

        /// <summary>
        /// Monster class constructor
        /// </summary>
        /// <param name="id">Monster ID</param>
        /// <param name="name">Monster Name</param>
        /// <param name="minimumDamage">Monster Minumum Damage</param>
        /// <param name="maximumDamage">Monster Maximum Damage</param>
        /// <param name="minimumProtection">Monster Minimum Protection</param>
        /// <param name="maximumProtection">Monster Maximum Protection</param>
        /// <param name="rewardExperiencePoints">After kill the moster this is the reward in experience points</param>
        /// <param name="rewardGold">After kill the moster this is the reward in gold</param>
        /// <param name="currentHitPoints">Monster Current HP</param>
        /// <param name="maximumHitPoints">Monster Maximum HP</param>
        public Monster(int id,
                       string name,
                       int minimumDamage,
                       int maximumDamage,
                       int minimumProtection,
                       int maximumProtection,
                       int rewardExperiencePoints,
                       int rewardGold,
                       int currentHitPoints,
                       int maximumHitPoints) : base(minimumDamage, maximumDamage, minimumProtection, maximumProtection, currentHitPoints, maximumHitPoints)
        {
            ID = id;
            Name = name;
            //MaximumDamage = maximumDamage;
            //MinimumProtection = minimumProtection;
            //MaximumProtection = maximumProtection;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            LootTable = new List<LootItem>();
        }
    }
}
