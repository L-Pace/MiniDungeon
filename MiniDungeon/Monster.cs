using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class Monster : LifeForm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        public int MaximumProtection { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }

        public List<LootItem> LootTable { get; set; }


        public Monster(int id, string name, int maximumDamage, int maximumProtection, int rewardExperiencePoints, int rewardGold, int currentHitPoints, int maximumHitPoints) : base(currentHitPoints, maximumHitPoints) 
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            MaximumProtection = maximumProtection;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            LootTable = new List<LootItem>();
        }
    }
}
