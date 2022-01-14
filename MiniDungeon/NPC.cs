using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDungeon
{
    public class NPC
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string QuestDialogue { get; set; }

        public string QuestNotCompleted { get; set; }

        public string CompletedQuestDialogue { get; set; }
        public string Dialogue { set; get; }

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
