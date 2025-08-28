using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Class Life Form
    /// </summary>
    public class LifeForm
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int MinimumProtection { get; set; }
        public int MaximumProtection { get; set; }
        public int MaximumHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        /// <summary>
        /// Constructor of Life Form
        /// </summary>
        /// <param name="minimumDamage">Minimum Damage</param>
        /// <param name="maximumDamage">Maximum Damage</param>
        /// <param name="minimumProtection">Minimum Protection</param>
        /// <param name="maximumProtection">Maximum Protection</param>
        /// <param name="maximumHitPoints">Max HP</param>
        /// <param name="currentHitPoints">Current HP</param>
        public LifeForm(int minimumDamage,
                        int maximumDamage,
                         int minimumProtection,
                        int maximumProtection,
                        int maximumHitPoints,
                        int currentHitPoints)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            MinimumProtection = minimumProtection;
            MaximumProtection = maximumProtection;
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = currentHitPoints;
        }
    }
}
