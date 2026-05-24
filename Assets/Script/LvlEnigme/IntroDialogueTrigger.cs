using UnityEngine;

public class IntroDialogueTrigger : MonoBehaviour
{
    [Header("Lignes du dialogue d'introduction")]
    [TextArea(3, 5)] 
    public string[] introLines;

    void Start()
    {
        if (DialogueManager.instance != null)
        {

            DialogueManager.instance.StartDialogue(introLines);
        }
        else
        {
            Debug.LogError("DialogueManager introuvable dans la scène !");
        }
    }


}
