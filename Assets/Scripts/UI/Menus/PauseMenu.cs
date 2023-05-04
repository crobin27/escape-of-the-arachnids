using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Options()
    {
        UIManager.Instance.ShowOptionsPanel();
    }

    public void ReturnToGame()
    {
        UIManager.Instance.HidePausePanel();
    }

    public void ReturnToStart()
    {
        UIManager.Instance.ShowStartPanel();
    }

}
