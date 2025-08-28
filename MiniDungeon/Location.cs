using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// Location class
    /// </summary>
    public class Location
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item ItemRequiredToEnter { get; set; }
        public Quest QuestAvailableHere { get; set; }
        public NPC NpcLivingHere { get; set; }
        public Monster MonsterLivingHere {get; set;}
        public Vendor VendorWorkingHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }

        /// <summary>
        /// Constructor of Location class
        /// </summary>
        /// <param name="id">Location ID</param>
        /// <param name="name">Location Name</param>
        /// <param name="description">Location Descriptiom</param>
        /// <param name="itemRequiredToEnter">In case the player need a certain item to enter the location we have a ref</param>
        /// <param name="questAvailableHere">Ref at quest in that location </param>
        /// <param name="monsterLivingHere">Ref at moster that lives in that locatiob</param>
        public Location(int id,
                        string name,
                        string description,
                        Item itemRequiredToEnter = null,
                        Quest questAvailableHere = null,
                        Monster monsterLivingHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailableHere;
            MonsterLivingHere = monsterLivingHere;
        }

    }

}
