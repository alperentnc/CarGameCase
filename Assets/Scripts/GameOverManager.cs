using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public TMP_Text currentScoreText;
    private void Awake()
    {
        GameOverPanel.SetActive(false);
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Day");
    }
    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayMenu");
    }
    public void CurrentScore(int currentScore)
    {
        currentScoreText.text = Mathf.Pow(2, currentScore).ToString();
    }
}
