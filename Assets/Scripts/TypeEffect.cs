using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public GameObject Cursor;
    public int CharPerSeconds;
    public bool isAnimation;

    TextMeshProUGUI msgText;
    AudioSource audioSource;
    string targetMsg;
    int idx;

    void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnimation)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        idx = 0;
        Cursor.SetActive(false);

        isAnimation = true;

        Invoke("Effecting", 1.0f / CharPerSeconds);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[idx];

        if (targetMsg[idx] != ' ' || targetMsg[idx] != '.')
            audioSource.Play();

        idx++;

        // Recursive
        Invoke("Effecting", 1.0f / CharPerSeconds);
    }
    void EffectEnd()
    {
        isAnimation = false;
        Cursor.SetActive(true);
    }
}
