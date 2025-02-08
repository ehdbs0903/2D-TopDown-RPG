using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TypeEffect DialogueBoxText;
    public Animator DialogueBox;
    public Animator PortraitAnimator;
    public DialogueManager dialogueManager;
    public Image PortraitImg;
    public QuestManager questManager;
    public bool isAction = false;
    public int dialogueIdx;

    GameObject scanObject;
    Sprite prevPortrait;

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
        DialogueBox.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNPC)
    {
        // Set Talk Data
        int questTalkIndex = 0;
        string dialogueData = "";
        if (DialogueBoxText.isAnimation)
        {
            DialogueBoxText.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            dialogueData = dialogueManager.GetDialogue(id + questTalkIndex, dialogueIdx);
        }

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
            DialogueBoxText.SetMsg(dialogueData.Split(':')[0]);
            PortraitImg.sprite = dialogueManager.GetPortrait(id, int.Parse(dialogueData.Split(':')[1]));
            PortraitImg.color = new Color(1, 1, 1, 1);
            if (prevPortrait != PortraitImg.sprite)
            {
                PortraitAnimator.SetTrigger("doEffect");
                prevPortrait = PortraitImg.sprite;
            }
        }
        else
        {
            DialogueBoxText.SetMsg(dialogueData);

            PortraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        dialogueIdx++;
    }
}
