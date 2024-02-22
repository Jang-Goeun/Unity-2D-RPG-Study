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
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:2", "저기 있는 집은 루나네 집이야.:1" });
        talkData.Add(2000, new string[] { "안녕!:0", "오늘 날씨가 정말 좋지?:2" });
        talkData.Add(100, new string[] { "평범한 나무 상자다." });
        talkData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });

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
