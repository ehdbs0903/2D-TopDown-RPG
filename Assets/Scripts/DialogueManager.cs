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
        dialogueData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1" });
        dialogueData.Add(2000, new string[] { "����:1", "�� ȣ���� ���� �Ƹ�����?:0", "��� �� ȣ������ ������ ����� ������ �ִٰ� ��:1" });
        dialogueData.Add(100, new string[] { "����� ���� ���ڴ�." });
        dialogueData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });

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
