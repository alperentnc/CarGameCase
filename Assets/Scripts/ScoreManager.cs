using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public int score = 1;
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    private void Awake()
    {
        PlayerPrefs.GetInt("highscore",0);
        if(PlayerPrefs.GetInt("highscore") != 0)
        {
            bestScoreText.text = "TOP SCORE :" + Mathf.Pow(2, PlayerPrefs.GetInt("highscore")).ToString();
        }
    }
    public void IncreaseScore()
    {
        score += 1;
        UpdateUI();
    }
    private void UpdateUI()
    {
        scoreText.text = Mathf.Pow(2,score).ToString();
    }
    public void UpdateHighScore()
    {
        if(score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
