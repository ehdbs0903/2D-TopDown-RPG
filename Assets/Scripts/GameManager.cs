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

    GameObject scanObject;
    public bool isAction = false;
    public int dialogueIdx;

    void Awake()
    {
        
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        DialogueBox.SetActive(isAction);
    }

    void Talk(int id, bool isNPC)
    {
        string dialogueData = dialogueManager.GetDialogue(id, dialogueIdx);

        if (dialogueData == null)
        {
            isAction = false;
            dialogueIdx = 0;
            return;
        }

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
