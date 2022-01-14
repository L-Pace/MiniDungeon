using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class Armor : Item
    {

        public int MinimumProtection { get; set; }
        public int MaximumProtection { get; set; }

        public Armor(int id, string name, string namePlural, float price, int minimumProtection, int maximumProtection, bool isWeapon = false, bool isArmor = true, bool isHealingPotion = false) : base(id, name, namePlural, price, isWeapon, isArmor, isHealingPotion)
        {
            MinimumProtection = minimumProtection;
            MaximumProtection = maximumProtection;
            IsWeapon = isWeapon;
            IsArmor = isArmor;
            IsHealingPotion = isHealingPotion;
        }


    }
}
