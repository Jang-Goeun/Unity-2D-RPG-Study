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
        //����Ʈ ����� �ش� ����Ʈ�� ������ NPC���� ID�Է�
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] {1000, 2000 }));
        questList.Add(20, new QuestData("�絵�� ���� ã���ֱ�", new int[] { 5000, 2000 }));
    }

    public int GetQuestTalkIndex(int id)  //NPC ID�� �޾� ����Ʈ ��ȣ ��ȯ
    {
        //����Ʈ ��ȣ + ����Ʈ ��ȭ ���� = ����Ʈ ��ȭ ID
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        //���� ����Ʈ ��ȭ��
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
