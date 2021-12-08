using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class QuestCompletitionItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }

        public QuestCompletitionItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
