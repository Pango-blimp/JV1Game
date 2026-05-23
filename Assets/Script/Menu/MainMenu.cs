using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    //  New Game
    public void StartGame()
    {
        SceneManager.LoadScene("Lvl1TheHouse"); // mets le nom exact de ta scène
    }

    // Settings
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    // Quit
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}