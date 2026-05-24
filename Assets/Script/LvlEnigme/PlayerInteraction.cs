using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
  
    public GameObject uiToToggle;

    public string targetTag = "Player";

    void Start()
    {
        if (uiToToggle != null)
        {
            uiToToggle.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag(targetTag))
        {
            if (uiToToggle != null)
            {
                uiToToggle.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            if (uiToToggle != null)
            {
                uiToToggle.SetActive(false);
            }
        }
    }
}
