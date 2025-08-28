using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Weapon class child of Item
    /// </summary>
    public class Weapon : Item
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        /// <summary>
        /// Constructor of Weapon class
        /// </summary>
        /// <param name="id">ID of the weapon</param>
        /// <param name="name">Name of the weapon</param>
        /// <param name="namePlural">Name plural of the weapon</param>
        /// <param name="price">Price of the weapon</param>
        /// <param name="minimumDamage">Minimum damage of the weapon</param>
        /// <param name="maximumDamage">Maximum Damage of the weapon</param>
        /// <param name="isWeapon">True</param>
        /// <param name="isArmor">False</param>
        /// <param name="isHealingPotion">False</param>
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
