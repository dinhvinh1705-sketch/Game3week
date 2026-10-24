using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1f;
        if (winPanel != null)
            winPanel.SetActive(false);
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        bool canReplay =
            (winPanel != null && winPanel.activeSelf) ||
            (gameOverPanel != null && gameOverPanel.activeSelf);
        if (canReplay &&
            Keyboard.current != null &&
            Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartLevel();
        }
    }
    public void ShowWin()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
    }
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
    public void LoadNextLevel()
    {
        int nextIndex =
            SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
    }
}
