using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateDate();
    }

    void GenerateDate()
    {
        //퀘스트 제목과 해당 퀘스트에 연관된 NPC들의 ID입력
        questList.Add(10, new QuestData("마을 사람들과 대화하기", new int[] {1000, 2000 }));
        questList.Add(20, new QuestData("루도의 동전 찾아주기", new int[] { 5000, 2000 }));
    }

    public int GetQuestTalkIndex(int id)  //NPC ID를 받아 퀘스트 번호 반환
    {
        //퀘스트 번호 + 퀘스트 대화 순서 = 퀘스트 대화 ID
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        //다음 퀘스트 대화로
        if (id == questList[questId].npcID[questActionIndex])
            questActionIndex++;

        //Control Quest Object
        ControlObject();

        if (questActionIndex == questList[questId].npcID.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
