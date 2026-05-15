using UnityEngine;

public class ShelfInteraction : MonoBehaviour
{
    [Header("Interaction")]
    public KeyCode interactionKey = KeyCode.E;
    public GameObject canvasToShow;
    public MonoBehaviour PlayerMovement;

    [Header("Detection")]
    public string playerTag = "Player";

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            ToggleCanvas();
        }
    }

    void ToggleCanvas()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(!canvasToShow.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = false;
        }
    }

    void OpenCanvas()
    {
        canvasToShow.SetActive(true);

        if (PlayerMovement != null)
            PlayerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseCanvas()
    {
        canvasToShow.SetActive(false);

        if (PlayerMovement != null)
            PlayerMovement.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}