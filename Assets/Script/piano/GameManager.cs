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
    public Slider hpBar;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void GoodHit()
    {
        score += 100;
        hp += goodHpGain;
        hp = Mathf.Clamp(hp, 0, maxHp);

        Debug.Log("GOOD | Score: " + score + " HP: " + hp);
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        hpBar.value = hp;

        scoreText.text = score.ToString("00000000");

    }

    public void Miss()
    {
        hp -= missHpLoss;

        Debug.Log("MISS | HP: " + hp);
        UpdateUI();
    }

    public void WrongInput()
    {
        hp -= wrongInputLoss;

        Debug.Log("WRONG | HP: " + hp);
        UpdateUI();
    }

    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
        }
    }
}
