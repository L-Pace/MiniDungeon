using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    /// <summary>
    /// NPC class
    /// </summary>
    public class NPC
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string QuestDialogue { get; set; }

        public string QuestNotCompleted { get; set; }

        public string CompletedQuestDialogue { get; set; }
        public string Dialogue { set; get; }

        /// <summary>
        /// NPC class contructor
        /// </summary>
        /// <param name="id">NPC ID</param>
        /// <param name="name">NPC Name</param>
        /// <param name="questDialogue">NPC quest dialogue</param>
        /// <param name="questNotCompleted">NPC dialogue when the quest is not completed</param>
        /// <param name="completedQuestDialogue">NPC dialogue if the quest has been completed</param>
        /// <param name="dialogue">NPC dialogue with no quest available</param>
        public NPC(int id, string name, string questDialogue,string questNotCompleted, string completedQuestDialogue, string dialogue)
        {
            ID = id;
            Name = name;
            QuestDialogue = questDialogue;
            QuestNotCompleted = questNotCompleted;
            CompletedQuestDialogue = completedQuestDialogue;
            Dialogue = dialogue;
        }
    }
}
