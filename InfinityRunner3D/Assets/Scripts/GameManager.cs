
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager instance;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    private int highScore;

    
    public PlayerMovement player;
    public float speedIncreaseAmount = 0.5f;  
    public int scorePerSpeedIncrease = 5;     
    public float maxSpeed = 20f;              

    private void Awake()
    {
        instance = this;
        gameOverPanel.SetActive(false);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Récord: " + highScore;
    }

    public void IncremetScore()
    {
        score++;
        scoreText.text = "Puntos: " + score;

        
        if (score % scorePerSpeedIncrease == 0)
        {
            IncreaseSpeed();
        }
    }

    void IncreaseSpeed()
    {
        if (player != null && player.speed < maxSpeed)
        {
            player.speed += speedIncreaseAmount;
        }
    }

    public void ShowGameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            finalScoreText.text = "Puntaje final: " + score + "\n¡Nuevo récord!";
        }
        else
        {
            finalScoreText.text = "Puntaje final: " + score;
        }

        highScoreText.text = "Récord: " + highScore;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}