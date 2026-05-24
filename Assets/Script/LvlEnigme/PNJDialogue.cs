using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    /*public string[] dialogueLines;

    public KeyCode interactionKey = KeyCode.E;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            DialogueManager.instance.StartDialogue(dialogueLines);
        }

        // passer au texte suivant
        if (DialogueManager.instance != null &&
            Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.instance.NextLine();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }*/
    public string[] dialogueLines;
    public KeyCode interactionKey = KeyCode.E;
    private bool playerInRange = false;

    void Update()
    {
        // On ne gère plus que l'ouverture du dialogue avec le PNJ
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            DialogueManager.instance.StartDialogue(dialogueLines);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
