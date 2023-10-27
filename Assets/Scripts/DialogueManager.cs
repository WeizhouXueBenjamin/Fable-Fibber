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
        // Initialize dialogues here, e.g., load from a data structure.
        dialogues = new string[]
        {
            "You are a villager of a nearby town.",
            "You have a habit of causing trouble.",
            "You've been given an allowance of 10 gold. It may come in handy later.",
            "Woods to the left. Town to the right."
        };

        // Start displaying the first dialogue.
        ShowCurrentDialogue();
    }

    public void TriggerDialogue()
    {
        // Display the next dialogue when triggered.
        currentDialogueIndex++;
        // Check if there are more dialogues to show.
        if (currentDialogueIndex < dialogues.Length)
        {
            ShowCurrentDialogue();
        }
        else
        {
            // No more dialogues, perform any closing action here.
            // For example, close the dialogue box or end the conversation.
        }
    }

    private void ShowCurrentDialogue()
    {
        dialogueMessage.text = dialogues[currentDialogueIndex];
    }
}
