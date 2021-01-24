using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int currentLevel = 1;
    CameraController camController;

    // Start is called before the first frame update
    void Start()
    {
        camController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moveSceneToLevel(int level)
    {
        currentLevel = level;
        camController.moveTo(level);

    }


}
