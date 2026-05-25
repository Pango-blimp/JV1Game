using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{
    [Header("Timer")]
    public float levelDuration = 60f; // durée du niveau
    private float timer;
    private bool levelEnded = false;

    [Header("UI")]
    public GameObject successCanvas;
    public TextMeshProUGUI scoreText;

    [Header("Gameplay")]
    public GameObject gameplayUI; // CanvasIndicateurTouche
    public GameObject noteSpawner;
    public AudioSource musicSource;

    [Header("Scene")]
    public string hubSceneName = "Hub";

    void Start()
    {
        timer = levelDuration;
        successCanvas.SetActive(false);
    }

    void Update()
    {
        if (levelEnded) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        levelEnded = true;

        Debug.Log("LEVEL COMPLETE");

        // Stop musique
        if (musicSource != null)
            musicSource.Stop();

        // Désactiver gameplay
        if (gameplayUI != null)
            gameplayUI.SetActive(false);

        if (noteSpawner != null)
            noteSpawner.SetActive(false);

        // Afficher UI succès
        successCanvas.SetActive(true);

        // Afficher score final
        if (scoreText != null)
            scoreText.text = GameManager.instance.score.ToString("00000000");

        // Pause du jeu
        Time.timeScale = 0f;
    }

    // Bouton Back
    public void BackToHub()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(hubSceneName);
    }
}
