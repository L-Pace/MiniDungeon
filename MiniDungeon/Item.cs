using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Class Item
    /// </summary>
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public float Price { get; set; }
        public bool IsWeapon { get; set; } 
        public bool IsArmor { get; set; }
        public bool IsHealingPotion { get; set; }

        /// <summary>
        /// Item class contructor
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <param name="name">Item Name</param>
        /// <param name="namePlural">Item Name, plural</param>
        /// <param name="price">Item Price</param>
        /// <param name="isWeapon">Bool set up to false</param>
        /// <param name="isArmor">Bool set up to false</param>
        /// <param name="isHealingPotion">Bool set up to false</param>
        public Item(int id, string name, string namePlural, float price, bool isWeapon = false, bool isArmor = false, bool isHealingPotion = false)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Price = price;
            IsWeapon = isWeapon;
            IsArmor = isArmor;
            IsHealingPotion = isHealingPotion;
        }

    }


}
