using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueLoader : MonoBehaviour
{
    public string targetSceneName; // Name of the scene to load
    public DialogueTrigger dialogueTrigger; // Reference to the DialogueTrigger script

    private void Start()
    {
        // Load the target scene when entering this scene
        SceneManager.LoadScene(1);

        // Call the StartDialogue function from DialogueTrigger (if it's not null)
        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue();
        }
    }
}
