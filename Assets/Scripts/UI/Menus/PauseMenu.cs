using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;

    public void Options()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);

    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackFromOptions()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

}
