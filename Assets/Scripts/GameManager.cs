using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject respawnPoint;

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
