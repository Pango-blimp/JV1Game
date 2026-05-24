using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public PlayerMovement playerMovement;

    private string[] lines;
    private int index;
    private bool isDialogueActive = false;

    public static DialogueManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
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
        isDialogueActive = true;
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
        isDialogueActive = false; 

        if (playerMovement != null)
            playerMovement.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
