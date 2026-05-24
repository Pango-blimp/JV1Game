using UnityEngine;

public class IntroDialogueTrigger : MonoBehaviour
{
    [Header("Lignes du dialogue d'introduction")]
    [TextArea(3, 5)] // Permet d'avoir une zone de texte plus confortable dans l'inspecteur Unity
    public string[] introLines;

    void Start()
    {
        // On vérifie si le DialogueManager existe bien dans la scène
        if (DialogueManager.instance != null)
        {
            // On lance le dialogue d'introduction immédiatement
            DialogueManager.instance.StartDialogue(introLines);
        }
        else
        {
            Debug.LogError("DialogueManager introuvable dans la scène !");
        }
    }


}
