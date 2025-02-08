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
        dialogueData.Add(1000, new string[] { "�ȳ�?:0",
                                            "�� ���� ó�� �Ա���?:1" });
        dialogueData.Add(2000, new string[] { "����:1",
                                            "�� ȣ���� ���� �Ƹ�����?:0",
                                            "��� �� ȣ������ ������ ����� ������ �ִٰ� ��:1" });
        dialogueData.Add(100, new string[] { "����� ���� ���ڴ�." });
        dialogueData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });


        // Quest Talk
        dialogueData.Add(10 + 1000, new string[] { "� ��.:0",
                                                "�� ������ ���� ������ �ִٴµ�:1",
                                                "������ ȣ�� �ʿ� �絵�� �˷��ٰž�.:0"});
        dialogueData.Add(11 + 2000, new string[] { "����:1",
                                                "�� ȣ���� ������ ������ �°ž�?:0",
                                                "�׷� �� �� �ϳ� ���ָ� �����ٵ�...:1",
                                                "�� �� ��ó�� ������ ���� �� �ֿ������� ��.:1"});
        dialogueData.Add(20 + 1000, new string[] { "�絵�� ����?:1",
                                                "���� �긮�� �ٴϸ� ������!:3",
                                                "���߿� �絵���� �� ���� �ؾ߰ھ�!:3",
                                                "�絵�� ���� �ʷϻ��̾�.:1"});
        dialogueData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��.:1"});
        dialogueData.Add(20 + 5000, new string[] { "��ó���� ������ ã�Ҵ�."});
        dialogueData.Add(21 + 2000, new string[] { "ã���༭ ����!!:2"});


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
