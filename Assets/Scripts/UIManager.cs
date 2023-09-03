using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverPrefab; 
    private GameObject gameOverInstance;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    public void ShowGameOverWindow(int currentScore, int highScore) {

        // Instantiate the game over window prefab and set it as a child of the container.
        gameOverInstance = Instantiate(gameOverPrefab);
    }

    public void HideGameOverWindow() {

        // Destroy the game over window instance.
        if (gameOverInstance != null) {
            Destroy(gameOverInstance);
        }
    }
}
