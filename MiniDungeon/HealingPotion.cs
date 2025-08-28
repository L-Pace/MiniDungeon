using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Healing Potion class
    /// </summary>
    public class HealingPotion : Item
    {
        public int AmountToHeal { get; set; }

        /// <summary>
        /// Healing Potion class constructor
        /// </summary>
        /// <param name="id">Healing Potion ID</param>
        /// <param name="name">Healing Potion Name</param>
        /// <param name="namePlural">Healing Potion Name Plural</param>
        /// <param name="price">Healing Potion Price</param>
        /// <param name="amountToHeal">Restore a certain amount of HP</param>
        /// <param name="isWeapon">Bool set it up to false</param>
        /// <param name="isArmor">Bool set it up to false</param>
        /// <param name="isHealingPotion">Bool set it up to true</param>
        public HealingPotion(int id,
                             string name,
                             string namePlural,
                             float price,
                             int amountToHeal,
                             bool isWeapon = false,
                             bool isArmor = false,
                             bool isHealingPotion = true) : base(id, name, namePlural, price, isWeapon, isArmor, isHealingPotion)
        {
            AmountToHeal = amountToHeal;
            IsWeapon = isWeapon;
            IsArmor = isArmor;
            IsHealingPotion = isHealingPotion;
        }
    }

}
