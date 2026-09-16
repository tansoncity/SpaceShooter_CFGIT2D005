using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _bgm;

    public void Start() 
    {
        _gameOverPanel.SetActive(false);
        _victoryPanel.SetActive(false);
    }

    public void GameOver()
    {
        StopGame();
        _gameOverPanel.SetActive(true);
    }

    public void Victory()
    {
        StopGame();
        _victoryPanel.SetActive(true);
    }

    private void StopGame()
    {
        _bgm.SetActive(false);
        Time.timeScale = 0f;
    }

    public void TryAgain() => SceneManager.LoadScene("Battle");

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
