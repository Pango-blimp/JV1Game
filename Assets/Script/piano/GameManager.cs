using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    public float hp = 100f;
    public float maxHp = 100f;

    [Header("HP Settings")]
    public float goodHpGain = 2f;
    public float missHpLoss = 5f;
    public float wrongInputLoss = 8f;

    [Header("UI")]
    public Slider hpBar;
    public TextMeshProUGUI scoreText;

    public GameObject gameplayUI;     
    public GameObject failUI;        

    [Header("Audio")]
    public AudioSource musicSource;

    private bool isGameOver = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();

        
        failUI.SetActive(false);
    }

    void UpdateUI()
    {
        hpBar.value = hp;
        scoreText.text = score.ToString("00000000");
    }

    public void GoodHit()
    {
        score += 100;
        hp += goodHpGain;
        hp = Mathf.Clamp(hp, 0, maxHp);

        UpdateUI();

        Debug.Log("GOOD | Score: " + score + " HP: " + hp);
    }

    public void Miss()
    {
        hp -= missHpLoss;
        UpdateUI();

        Debug.Log("MISS | HP: " + hp);
        CheckGameOver();
    }

    public void WrongInput()
    {
        hp -= wrongInputLoss;
        UpdateUI();

        Debug.Log("WRONG | HP: " + hp);
        CheckGameOver();
    }

    void CheckGameOver()
    {
        if (hp <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("GAME OVER");

        if (musicSource != null)
            musicSource.Stop();

        if (gameplayUI != null)
            gameplayUI.SetActive(false);

        
        if (failUI != null)
            failUI.SetActive(true);

       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        
        Time.timeScale = 0f;
    }

    
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    public void BackToHub()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl1TheHouse"); 
    }
}
