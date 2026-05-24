using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    /*public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public PlayerMovement playerMovement;

    private string[] lines;
    private int index;

    public static DialogueManager instance;

    void Awake()
    {
        instance = this;
    }

    public void StartDialogue(string[] dialogueLines)
    {
        lines = dialogueLines;
        index = 0;

        dialoguePanel.SetActive(true);
        ShowLine();
        if (playerMovement != null)
            playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ShowLine()
    {
        if (dialogueText == null)
        {
            Debug.LogError("DialogueText non assigné !");
            return;
        }

        dialogueText.text = lines[index];
    }

    public void NextLine()
    {
        index++;

        if (index >= lines.Length)
        {
            EndDialogue();
        }
        else
        {
            ShowLine();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        if (playerMovement != null)
            playerMovement.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }*/
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public PlayerMovement playerMovement;

    private string[] lines;
    private int index;
    private bool isDialogueActive = false; // Ajout d'une sécurité

    public static DialogueManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Si un dialogue est en cours et que le joueur appuie sur Espace
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        lines = dialogueLines;
        index = 0;

        dialoguePanel.SetActive(true);
        isDialogueActive = true; // Le dialogue commence
        ShowLine();

        if (playerMovement != null)
            playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ShowLine()
    {
        if (dialogueText == null)
        {
            Debug.LogError("DialogueText non assigné !");
            return;
        }

        dialogueText.text = lines[index];
    }

    public void NextLine()
    {
        index++;

        if (index >= lines.Length)
        {
            EndDialogue();
        }
        else
        {
            ShowLine();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false; // Le dialogue est fini

        if (playerMovement != null)
            playerMovement.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
