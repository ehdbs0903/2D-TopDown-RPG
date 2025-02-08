using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Dictionary<int, string[]> dialogueData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        dialogueData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        // Luna : 1000, Ludo : 2000, Box : 100, Desk : 200
        dialogueData.Add(1000, new string[] { "안녕?:0",
                                            "이 곳에 처음 왔구나?:1" });
        dialogueData.Add(2000, new string[] { "여어:1",
                                            "이 호수는 정말 아름답지?:0",
                                            "사실 이 호수에는 무언가의 비밀이 숨겨져 있다고 해:1" });
        dialogueData.Add(100, new string[] { "평범한 나무 상자다." });
        dialogueData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });


        // Quest Talk
        dialogueData.Add(10 + 1000, new string[] { "어서 와.:0",
                                                "이 마을에 놀라운 전설이 있다는데:1",
                                                "오른쪽 호수 쪽에 루도가 알려줄거야.:0"});
        dialogueData.Add(11 + 2000, new string[] { "여어:1",
                                                "이 호수의 전설을 들으러 온거야?:0",
                                                "그럼 일 좀 하나 해주면 좋을텐데...:1",
                                                "내 집 근처에 떨어진 동전 좀 주워줬으면 해.:1"});
        dialogueData.Add(20 + 1000, new string[] { "루도의 동전?:1",
                                                "돈을 흘리고 다니면 못쓰지!:3",
                                                "나중에 루도에게 한 마디 해야겠어!:3",
                                                "루도의 집은 초록색이야.:1"});
        dialogueData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘.:1"});
        dialogueData.Add(20 + 5000, new string[] { "근처에서 동전을 찾았다."});
        dialogueData.Add(21 + 2000, new string[] { "찾아줘서 고마워!!:2"});


        // 0 : Normal, 1 : Speak, 2 : Happy, 3: Angry
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetDialogue(int id, int dialogueIdx)
    {
        if (!dialogueData.ContainsKey(id))
        {
            if (!dialogueData.ContainsKey(id - id % 10))
            {
                return GetDialogue(id - id % 100, dialogueIdx);
            }
            return GetDialogue(id - id % 10, dialogueIdx);
        }

        if (dialogueIdx == dialogueData[id].Length)
        {
            return null;
        }
        return dialogueData[id][dialogueIdx];
    }

    public Sprite GetPortrait(int id, int portraitIdx)
    {
        return portraitData[id + portraitIdx];
    }
}
