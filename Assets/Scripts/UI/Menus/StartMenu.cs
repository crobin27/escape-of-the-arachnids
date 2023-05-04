using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject startPanel;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        startPanel.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void OpenOptions()
    {
        startPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void StartOptionsBack()
    {
        optionsPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
