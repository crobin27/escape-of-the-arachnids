using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    [SerializeField]private GameObject startPanel;
    [SerializeField]private GameObject pausePanel;
    [SerializeField]private GameObject optionsPanel;
    [SerializeField]private GameObject endGamePanel;
    [SerializeField]private GameObject winGamePanel;

    public bool isPlaying;    // used to know where the user pressed the options button

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        if (!isPlaying)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        Time.timeScale = 0;
        ShowStartPanel();
    }

    public void ShowStartPanel()
    {
        DeactivateAllPanels();
        startPanel.SetActive(true);
    }

    public void ShowPausePanel()
    {
        DeactivateAllPanels();
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
        if(isPlaying)
        {
            ShowPausePanel();
        }
        else
        {
            ShowStartPanel();
        }
    }

    public void ShowOptionsPanel()
    {
        DeactivateAllPanels();
        optionsPanel.SetActive(true);
    }

    public void ShowEndGamePanel()
    {
        DeactivateAllPanels();
        endGamePanel.SetActive(true);
    }

    public void ShowWinGamePanel()
    {
        DeactivateAllPanels();
        winGamePanel.SetActive(true);
    }

    public void DeactivateAllPanels()
    {
        startPanel.SetActive(false);
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        endGamePanel.SetActive(false);
        winGamePanel.SetActive(false);
    }
}