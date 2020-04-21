using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIController uiController;

    private bool _gameStarted;
    private bool _gameEnded;

    private void Start()
    {
        _gameStarted = false;
        _gameEnded = false;
        uiController.SetWelcomeScreenActive(true);
        uiController.SetInGameUIActive(false);
        uiController.SetGameOverActive(false);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (!_gameStarted && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        if (_gameStarted && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _gameStarted = true;
        uiController.SetWelcomeScreenActive(false);
        uiController.SetInGameUIActive(true);
    }

    public void GameOver()
    {
        _gameEnded = true;
        uiController.SetInGameUIActive(false);
        uiController.SetGameOverActive(true);
        Time.timeScale = 0;
    }
}
