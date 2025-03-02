using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class EnemyCar : MonoBehaviour
{
    public TMP_Text scoreText;
    private int carScore;
    List<int> potentialScores = new List<int>();
    private GameObject player;
    private PlayerController playerController;
    private ScoreManager scoreManager;
    private HealthController healthController;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        scoreManager = player.GetComponent<ScoreManager>();
        healthController = player.GetComponent<HealthController>();
    }
    void Start()
    {
        Debug.Log(scoreManager.score);
    }
    private void OnEnable()
    {
        if (scoreManager.score == 1)
        {
            potentialScores.AddRange(new int[] { 1, 2 });
            carScore = potentialScores[Random.Range(0, 2)];
            potentialScores.Clear();
        }
        else if (scoreManager.score == 2)
        {
            potentialScores.AddRange(new int[] { 1, 2, 3 });
            carScore = potentialScores[Random.Range(0, 3)];
            potentialScores.Clear();
        }
        else
        {
            potentialScores.AddRange(new int[] { scoreManager.score - 2, scoreManager.score - 1, scoreManager.score, scoreManager.score + 1 });
            carScore = potentialScores[Random.Range(0, 4)];
            potentialScores.Clear();
        }
        scoreText.text = Mathf.Pow(2, carScore).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (scoreManager.score == carScore)
            {
                scoreManager.IncreaseScore();
                playerController.SpeedBooster();
            }
            else if(scoreManager.score < carScore)
            {
                healthController.DecreaseHealth(100);
            }
            else
            {
                healthController.DecreaseHealth(60-((scoreManager.score-carScore)*10));
            }
        }
    }
}
