using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueObject;
    public TMP_Text dialgoueText;
    private string intro1 = "You are a villager of a nearby town.";
    private string intro2 = "You have a habit of causing trouble.";
    private string intro3 = "You've been given an allowance of 10 gold. It may come in handy later.";
    private string introDir = "Woods to the left. Town to the right.";

    public void Start()
    {
        dialogueObject.SetActive(true);
        dialgoueText.text = intro1;
        float scale = 0.1f;
        // dialogueObject.transform.localScale = new Vector3(scale, scale, scale);
        // RectTransform rectTransform = dialogueObject.GetComponent<RectTransform>();
        // rectTransform.sizeDelta = new Vector3(scale, scale, scale);
        
    }

    public void Intro2() { dialgoueText.text = intro2; }
    public void Intro3() { dialgoueText.text = intro3; }
    public void IntroDir() { dialgoueText.text = introDir; }


}
