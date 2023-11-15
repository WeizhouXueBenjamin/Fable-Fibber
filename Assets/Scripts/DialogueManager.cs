using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueMessage;
    private string[] dialogues;
    private int currentDialogueIndex = 0;

    public void Start()
    {
        dialogues = new string[]
        {
            "You are a villager of a nearby town.",
            "You have a habit of causing trouble.",
            "You've been given an allowance of 10 gold. It may come in handy later.",
            "Woods to the left. Town to the right."
        };

        ShowCurrentDialogue();
    }

    public void TriggerDialogue()
    {
        currentDialogueIndex++;

        if (currentDialogueIndex < dialogues.Length)
        {
            ShowCurrentDialogue();
        }
        else
        {
            // No more dialogues, perform any closing action here.
        }
    }

    private void ShowCurrentDialogue()
    {
        dialogueMessage.text = dialogues[currentDialogueIndex];
    }
}
