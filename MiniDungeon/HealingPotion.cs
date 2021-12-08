using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class HealingPotion : Item
    {
        public int AmountToHeal { get; set; }

        public HealingPotion(int id, string name, string namePlural, float price, int amountToHeal) : base(id, name, namePlural, price)
        {
            AmountToHeal = amountToHeal;
        }
    }

}
