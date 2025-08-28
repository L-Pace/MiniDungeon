using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Class for LootItem that is defining the loot of a killed monster
    /// </summary>
    public class LootItem
    {
        public Item Details { get; set; }
        public int DropPercentage { get; set; }
        public bool IsDefaultItem { get; set; }
        
        /// <summary>
        /// LootItem constructor
        /// </summary>
        /// <param name="details">Ref to Item class</param>
        /// <param name="dropPercentage">Drop percentage of the item</param>
        /// <param name="isDefaultItem">Bool if is a default item or not</param>
        public LootItem(Item details, int dropPercentage, bool isDefaultItem)
        {
            Details = details;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}
