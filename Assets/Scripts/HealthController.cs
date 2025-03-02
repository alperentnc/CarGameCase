using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class HealthController : MonoBehaviour
{
    public GameOverManager gameOverManager;
    public TMP_Text healthText;
    private int health = 100;
    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        healthText.text = health.ToString();
    }

    void Update()
    {
        
    }
    public void DecreaseHealth(int damage)
    {
        health -= damage;
        if (health <= 0) { health = 0; Time.timeScale = 0f; scoreManager.UpdateHighScore(); gameOverManager.GameOver(); }
        healthText.text = health.ToString();
    }
}
