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
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1", "한번 둘러보도록 해.:0" });
        talkData.Add(2000, new string[] { "여어.:1", "이 호수는 정말 아름답지?:0", "사실 이 호수에는 무언가 비밀이 숨겨져있다고 해.:1"});
        talkData.Add(100, new string[] { "평범한 나무 상자다." });
        talkData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
    
        //퀘스트 대화 데이터, 퀘스트 번호 + NPC ID
        talkData.Add(10 + 1000, new string[] { "어서와.: 0", 
                                                "이 마을에 놀라운 전설이 있다는데:1" , 
                                                "왼쪽 호수에 있는 루도가 알려줄거야.:0"});
        talkData.Add(11 + 2000, new string[] { "여어.:1", "혹시 이 호수의 전설을 들으러 온거야?:0", "그럼 일 좀 하나 해주면 좋을텐데...:1", "내 집 근처에 떨어진 동전 좀 주워줬으면 해:2" });
        talkData.Add(20 + 1000, new string[] { "루도의 동전?:1",
                                                "돈을 흘리고 다니면 못쓰지!:3" ,
                                                "나중에 루도에게 한마디 해야겠어.:3"});
        talkData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘.:1", });
        talkData.Add(20 + 5000, new string[] { "근처에서 동전을 찾았다.", });
        talkData.Add(21 + 2000, new string[] { "엇, 찾아줘서 고마워.:2",  });

        //초상화 데이터, NPC ID +초상화 번호
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
        {  // id가 없으면 퀘스트 대화순서 제거 후 재탐색
            if (!talkData.ContainsKey(id - id % 10)) { // 퀘스트 맨 처음 대사마저 없을 때, 기본 대사를 가지고 온다
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {// 해당 퀘스트 진행 순서 대사가 없을 때, 퀘스트 맨 처음 대사를 가지고 온다.
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
