using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public SceneFader fader;

    public void StartGame()
    {
        GameManagerSave.instance.hasSavedPosition = false;
        GameManagerSave.instance.introDialogueDone = false;
        fader.FadeToScene("Lvl1TheHouse");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

   
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}