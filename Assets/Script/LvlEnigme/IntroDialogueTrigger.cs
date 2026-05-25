using UnityEngine;

public class IntroDialogueTrigger : MonoBehaviour
{
    [TextArea(3, 5)] 
    public string[] introLines;

    void Start()
    {
        if (GameManagerSave.instance.introDialogueDone)
            return;

        if (DialogueManager.instance != null)
        {

            DialogueManager.instance.StartDialogue(introLines);

            GameManagerSave.instance.introDialogueDone = true;
        }
        else
        {
            Debug.LogError("DialogueManager introuvable dans la scène !");
        }
    }


}
