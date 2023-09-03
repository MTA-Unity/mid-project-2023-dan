using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public void StartGame() {
        // Reload the current scene to try again.
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
