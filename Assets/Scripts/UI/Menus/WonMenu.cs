using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        UIManager.Instance.ShowStartPanel();
    }
}
