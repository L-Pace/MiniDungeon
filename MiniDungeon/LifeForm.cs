using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class LifeForm
    {
        public int MaximumHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        public LifeForm(int maximumHitPoints, int currentHitPoints)
        {
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = currentHitPoints;
        }
    }
}
