using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class Weapon : Item
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int id, string name, string namePlural, float price, int minimumDamage, int maximumDamage): base(id, name, namePlural, price)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }

    }
}
