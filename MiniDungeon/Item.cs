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

        public Item(int id, string name, string namePlural, float price)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Price = price;
        }

    }


}
