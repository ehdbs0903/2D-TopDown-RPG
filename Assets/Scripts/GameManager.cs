using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI DialogueBoxText;
    public GameObject DialogueBox;
    public DialogueManager dialogueManager;
    public Image PortraitImg;
    public QuestManager questManager;

    GameObject scanObject;
    public bool isAction = false;
    public int dialogueIdx;

    void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void Action(GameObject scanObj)
    {
        // Get Current Object
        scanObject = scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        // Visible Talk for Action
        DialogueBox.SetActive(isAction);
    }

    void Talk(int id, bool isNPC)
    {
        // Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string dialogueData = dialogueManager.GetDialogue(id + questTalkIndex, dialogueIdx);

        // End Talk
        if (dialogueData == null)
        {
            isAction = false;
            dialogueIdx = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        // Continue Talk
        if (isNPC)
        {
            DialogueBoxText.text = dialogueData.Split(':')[0];
            PortraitImg.sprite = dialogueManager.GetPortrait(id, int.Parse(dialogueData.Split(':')[1]));
            PortraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            DialogueBoxText.text = dialogueData;

            PortraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        dialogueIdx++;
    }
}
