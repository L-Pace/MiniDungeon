using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class Item
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public float Price { get; set; }
        public bool IsWeapon { get; set; } 
        public bool IsArmor { get; set; }
        public bool IsHealingPotion { get; set; }



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
