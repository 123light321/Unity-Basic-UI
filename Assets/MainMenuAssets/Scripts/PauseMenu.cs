using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private GameObject _pausedPanel;

    public void pauseGame()
    {
        _pauseButton.SetActive(false);
        Time.timeScale = 0f;
        _pausedPanel.SetActive(true);
    }

    public void resumeGame()
    {
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
        _pausedPanel.SetActive(false);
    }

    public void loadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
