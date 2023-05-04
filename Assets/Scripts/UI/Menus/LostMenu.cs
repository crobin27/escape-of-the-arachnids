using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        UIManager.Instance.ShowStartPanel();
    }
}
