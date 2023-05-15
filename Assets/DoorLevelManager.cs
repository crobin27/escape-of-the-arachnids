using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorLevelManager : MonoBehaviour
{
    public Transform lvl1;
    public Transform lvl2;
    public Transform lvl3;
    public Transform lvl4;

    private Transform[] levels;
    private int currentLevel = 0;

    private void Start()
    {
        levels = new Transform[] { lvl1, lvl2, lvl3, lvl4 };
    }

    public void GoForward()
    {
        currentLevel++;
        if (currentLevel >= levels.Length) currentLevel = levels.Length - 1; //Prevent going out of bounds
        PlayerController.Instance.gameObject.transform.position = levels[currentLevel].position;
    }

    public void BackToStart()
    {
        currentLevel = 0;
        PlayerController.Instance.gameObject.transform.position = lvl1.position;
    }

}
