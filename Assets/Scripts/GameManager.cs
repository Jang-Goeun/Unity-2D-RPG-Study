using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public Image portraitImg;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction; // ��ȭâ Ȱ��ȭ ���� üũ
    public int talkIndex;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        //��ȭ ������ �ҷ�����
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if (isNpc) {    //NPC���
            talkText.text = talkData.Split(':')[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);  //�ʻ�ȭ ���̱�
        }
        else {  //NPC�� �ƴ϶��
            talkText.text = talkData;

            portraitImg.color = new Color(1, 1, 1, 0);  //�ʻ�ȭ ����ȭ
        }

        isAction = true;
        talkIndex++;
    }
}

