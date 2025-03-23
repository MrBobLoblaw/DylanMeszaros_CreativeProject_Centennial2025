using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class MessageManager : MonoBehaviour
{
    public GameObject fullMessage;
    public TextMeshProUGUI fullMessageText;
    public GameObject halfMessage;
    public TextMeshProUGUI halfMessageText;

    private bool lastMessage = false;

    public SceneSwitcher sceneSwitcher;

    private void Start()
    {
        StopAllCoroutines();

        string sceneName = SceneManager.GetActiveScene().name;

        fullMessage.SetActive(true);
        fullMessageText.gameObject.SetActive(true);

        if (sceneName == "StrawLevel1")
        {
            ShowMessage("The sounds of friends and family eating together...", true, false, 3f);
        }
        else if (sceneName == "StrawLevel2")
        {
            ShowMessage("The straw and other garbage are thrown off a cliff into the ocean...", true, false, 3f);
        }
        else if (sceneName == "TurtleLevel1")
        {
            ShowMessage("The sounds of a family waking up... ...starting their day...", true, false, 3f);
        }
        else if (sceneName == "TurtleLevel2")
        {
            ShowMessage("The sounds of a shell reving up...", true, false, 3f);
        }
    }

    public void ShowMessage(string message, bool full, bool isLastMessage, float lifespan)
    {
        StopAllCoroutines();

        if (full)
        {
            fullMessage.SetActive(true);
            halfMessage.SetActive(false);
            fullMessageText.gameObject.SetActive(true);
            fullMessageText.text = message;
        }
        else
        {
            fullMessage.SetActive(false);
            halfMessage.SetActive(true);
            halfMessageText.gameObject.SetActive(true);
            halfMessageText.text = message;
        }

        StartCoroutine(HideMessagesAfterDelay(lifespan));
        StartCoroutine(HideTextsAfterDelay(lifespan * 0.85f));

        lastMessage = isLastMessage;
    }

    private IEnumerator HideMessagesAfterDelay(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);

        if (lastMessage)
        {
            sceneSwitcher.SwitchScene();
        }

        fullMessage.SetActive(false);
        halfMessage.SetActive(false);
    }
    private IEnumerator HideTextsAfterDelay(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        fullMessageText.gameObject.SetActive(false);
        halfMessageText.gameObject.SetActive(false);
    }
}
