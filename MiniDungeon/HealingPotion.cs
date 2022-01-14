using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class HealingPotion : Item
    {
        public int AmountToHeal { get; set; }

        public HealingPotion(int id, string name, string namePlural, float price, int amountToHeal, bool isWeapon = false, bool isArmor = false, bool isHealingPotion = true) : base(id, name, namePlural, price, isWeapon, isArmor, isHealingPotion)
        {
            AmountToHeal = amountToHeal;
            IsWeapon = isWeapon;
            IsArmor = isArmor;
            IsHealingPotion = isHealingPotion;
        }
    }

}
