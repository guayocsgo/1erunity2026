
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager instance;
    public TextMeshProUGUI scoreText;

    public void IncremetScore()
    {
        score++;
        scoreText.text = "Puntos: " + score;
    }

    private void Awake()
    {
        instance = this;
    }
}