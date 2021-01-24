using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 1;
    CameraController camController;

    void Start()
    {
        camController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    public void moveSceneToLevel(int level)
    {
        currentLevel = level;
        camController.moveTo(level);
    }

    public void nextLevel()
    {
        moveSceneToLevel(currentLevel + 1);
    }
}
