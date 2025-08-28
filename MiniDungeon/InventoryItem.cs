using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Inventory Item Class
    /// </summary>
    public partial class InventoryItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Inventory Item constructor
        /// </summary>
        /// <param name="details">Ref to Item</param>
        /// <param name="quantity">Inventory Item Quantity</param>
        public InventoryItem(Item details, int quantity)
        {

            Details = details;

            Quantity = quantity;
        }

    }
}
