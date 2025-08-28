using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDungeon
{
    public class Vendor
    {
        public string Name { get; set; }
        public List<InventoryItem> Inventory { get; private set; }
        public Vendor VendorWorkingHere { get; set; }

        /// <summary>
        /// Constructor of the class vendor. There are no references to this class because I didn't finished it.
        /// </summary>
        /// <param name="name"></param>
        public Vendor(string name)
        {
            Name = name;
            Inventory = new List<InventoryItem>();
        }

        /// <summary>
        /// Add the items to the inventory list of the vendor
        /// </summary>
        /// <param name="itemToAdd">Ref to the class Item</param>
        /// <param name="quantity">Quantity of the items</param>
        public void AddItemToVendorInventory(Item itemToAdd, int quantity = 1)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);

            if(item == null)
            {
                Inventory.Add(new InventoryItem(itemToAdd, quantity));
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        /// <summary>
        /// Removes the items from the inventory of the vendor
        /// </summary>
        /// <param name="itemToRemove">Ref to Item</param>
        /// <param name="quantity">Quantity of the items</param>
        public void RemoveItemFromTheInventory(Item itemToRemove, int quantity = 1)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToRemove.ID);

            if(item == null)
            {
                return;
            }
            else
            {
                item.Quantity -= quantity;

                if(item.Quantity < 0)
                {
                    item.Quantity = 0;
                }

                if(item.Quantity == 0)
                {
                    Inventory.Remove(item);
                }
            }

        }
    }
}
