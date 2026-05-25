using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string sceneToLoad;
    public KeyCode interactKey = KeyCode.E;
    public GameObject uiToToggle;

    private bool playerInZone = false;

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(interactKey))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                GameManagerSave.instance.SavePlayerPosition(player.transform.position);
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        if (playerInZone && uiToToggle !=null)
        {
            uiToToggle.SetActive(true);
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = false;
        }
        
    }
    public void LoadScene()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            GameManagerSave.instance.SavePlayerPosition(player.transform.position);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}