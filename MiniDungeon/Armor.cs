using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Class armor child of Item
    /// </summary>
    public class Armor : Item
    {
        public int MinimumProtection { get; set; }
        public int MaximumProtection { get; set; }

        /// <summary>
        /// Armor class constructor
        /// </summary>
        /// <param name="id">Armor ID</param>
        /// <param name="name">Armor Name</param>
        /// <param name="namePlural">Armor Name Plural</param>
        /// <param name="price">Armor Price</param>
        /// <param name="minimumProtection">Armor Minimum Protection</param>
        /// <param name="maximumProtection">Armor Maximum Protection</param>
        /// <param name="isWeapon">Bool set to false</param>
        /// <param name="isArmor">Bool set to true</param>
        /// <param name="isHealingPotion">Bool set to false</param>
        public Armor(int id,
                     string name,
                     string namePlural,
                     float price,
                     int minimumProtection,
                     int maximumProtection,
                     bool isWeapon = false,
                     bool isArmor = true,
                     bool isHealingPotion = false) : base(id, name, namePlural, price, isWeapon, isArmor, isHealingPotion)
        {
            MinimumProtection = minimumProtection;
            MaximumProtection = maximumProtection;
            IsWeapon = isWeapon;
            IsArmor = isArmor;
        }


    }
}
