using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class QuestCompletionItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Class for the item that the player needs to complete the quest
        /// </summary>
        /// <param name="details">Ref to item details</param>
        /// <param name="quantity">Quantity</param>
        public QuestCompletionItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
