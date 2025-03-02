using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverPanel;
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

    }
}
