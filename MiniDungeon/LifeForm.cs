using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class LifeForm
    {

        public int MaximumDamage { get; set; }
        public int MaximumProtection { get; set; }
        public int MaximumHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        public LifeForm(int maximumDamage,
                        int maximumProtection,
                        int maximumHitPoints,
                        int currentHitPoints)
        {
            MaximumDamage = maximumDamage;
            MaximumProtection = maximumProtection;
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = currentHitPoints;
        }
    }
}
