using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class Armor : Item
    {

        public int MinimumProtection { get; set; }
        public int MaximumProtection { get; set; }

        public Armor(int id, string name, string namePlural, float price, int minimumProtection, int maximumProtection) : base(id, name, namePlural, price)
        {
            MinimumProtection = minimumProtection;
            MaximumProtection = maximumProtection;
        }


    }
}
