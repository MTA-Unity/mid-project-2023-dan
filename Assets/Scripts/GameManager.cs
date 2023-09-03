using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] private UIManager uiManager;

    private int _highscore = 0; // Track the high score.
    private int _currentScore = 0; // Track the current score.
    private bool _isGameOver = false;

    private void Start() {
        // Subscribe to the PlayerController's OnObstacleHit event.
        PlayerController.OnObstacleHit += HandleObstacleHit;
    }

    private void HandleObstacleHit() {
        if (!_isGameOver) {
            _isGameOver = true;
            Time.timeScale = 0; // Pause the game.

            // Show the GameOver window with options.
            uiManager.ShowGameOverWindow(_currentScore, _highscore);
        }
    }

    public void Restart() {
        // Reload the current scene to try again.
        Time.timeScale = 1; // Resume the game.
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMainMenu() {
        // Load the main menu scene.
        Time.timeScale = 1; // Resume the game.
        SceneManager.LoadScene("MainMenu");
    }

}
