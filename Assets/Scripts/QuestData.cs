using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questName;
    public int[] npcID;

    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcID = npc;
    }
}
