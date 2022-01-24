using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class Weapon : Item
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int id,
                      string name,
                      string namePlural,
                      float price,
                      int minimumDamage,
                      int maximumDamage,
                      bool isWeapon = true,
                      bool isArmor = false,
                      bool isHealingPotion = false) : base(id, name, namePlural, price, isWeapon, isArmor, isHealingPotion)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            IsArmor = isArmor;
            IsWeapon = isWeapon;
            IsHealingPotion = isHealingPotion;
        }

    }
}
