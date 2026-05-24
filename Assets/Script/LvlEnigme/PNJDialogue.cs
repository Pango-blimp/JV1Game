using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject uiToToggle;
    public string[] dialogueLines;
    public KeyCode interactionKey = KeyCode.E;
    private bool playerInRange = false;

    void Update()
    {
        
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            DialogueManager.instance.StartDialogue(dialogueLines);
        }
        if (playerInRange && uiToToggle != null)
        {
            uiToToggle.SetActive(true);
        
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
