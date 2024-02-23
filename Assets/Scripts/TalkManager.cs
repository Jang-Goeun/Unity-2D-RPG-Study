using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateDate();
    }

    void GenerateDate()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1", "�ѹ� �ѷ������� ��.:0" });
        talkData.Add(2000, new string[] { "����.:1", "�� ȣ���� ���� �Ƹ�����?:0", "��� �� ȣ������ ���� ����� �������ִٰ� ��.:1"});
        talkData.Add(100, new string[] { "����� ���� ���ڴ�." });
        talkData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
    
        //����Ʈ ��ȭ ������, ����Ʈ ��ȣ + NPC ID
        talkData.Add(10 + 1000, new string[] { "���.: 0", 
                                                "�� ������ ���� ������ �ִٴµ�:1" , 
                                                "���� ȣ���� �ִ� �絵�� �˷��ٰž�.:0"});
        talkData.Add(11 + 2000, new string[] { "����.:1", "Ȥ�� �� ȣ���� ������ ������ �°ž�?:0", "�׷� �� �� �ϳ� ���ָ� �����ٵ�...:1", "�� �� ��ó�� ������ ���� �� �ֿ������� ��:2" });
        talkData.Add(20 + 1000, new string[] { "�絵�� ����?:1",
                                                "���� �긮�� �ٴϸ� ������!:3" ,
                                                "���߿� �絵���� �Ѹ��� �ؾ߰ھ�.:3"});
        talkData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��.:1", });
        talkData.Add(20 + 5000, new string[] { "��ó���� ������ ã�Ҵ�.", });
        talkData.Add(21 + 2000, new string[] { "��, ã���༭ ����.:2",  });

        //�ʻ�ȭ ������, NPC ID +�ʻ�ȭ ��ȣ
        //0:Idle, 1: Talk, 2:Smail, 3:Angry
        portraitData.Add(1000 + 0, portraitArr[0]); //Ludo Idle
        portraitData.Add(1000 + 1, portraitArr[1]); //Ludo Talk
        portraitData.Add(1000 + 2, portraitArr[2]); //Ludo Smile
        portraitData.Add(1000 + 3, portraitArr[3]); //Ludo Angry

        portraitData.Add(2000 + 0, portraitArr[4]); //Luna Idle
        portraitData.Add(2000 + 1, portraitArr[5]); //Luna Talk
        portraitData.Add(2000 + 2, portraitArr[6]); //Luna Smile
        portraitData.Add(2000 + 3, portraitArr[7]); //Luna Angry

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {  // id�� ������ ����Ʈ ��ȭ���� ���� �� ��Ž��
            if (!talkData.ContainsKey(id - id % 10)) { // ����Ʈ �� ó�� ��縶�� ���� ��, �⺻ ��縦 ������ �´�
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {// �ش� ����Ʈ ���� ���� ��簡 ���� ��, ����Ʈ �� ó�� ��縦 ������ �´�.
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
