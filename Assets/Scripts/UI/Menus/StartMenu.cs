using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("1");
        if (UIManager.Instance == null)
        {
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
            UIManager.Instance.DeactivateAllPanels();
        }
    }

    public void OpenOptions()
    {
        UIManager.Instance.ShowOptionsPanel();
    }
}
