using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI DialogueBoxText;
    public GameObject DialogueBox;

    GameObject scanObject;
    public bool isAction = false;

    void Awake()
    {
        
    }

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            DialogueBoxText.text = "�̰��� �̸��� " + scanObject.name + "�Դϴ�.";
        }

        DialogueBox.SetActive(isAction);
    }
}
