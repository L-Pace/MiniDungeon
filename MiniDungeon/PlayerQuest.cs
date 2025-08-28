using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class PlayerQuest
    {
        public Quest Details { get; set; }
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Player Quest
        /// </summary>
        /// <param name="details">Ref to the class Quest</param>
        public PlayerQuest(Quest details)
        {
            Details = details;
            IsCompleted = false;
        }
    }
}
