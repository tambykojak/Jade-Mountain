using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    
    private int lastLevel;

    IEnumerator TransitionToNewLevel(Vector3 newPos)
    {

        float diff = Mathf.Abs(transform.position.x - newPos.x)/100;

        while (transform.position.x != newPos.x)
        {
            transform.position = new Vector3(transform.position.x+diff, transform.position.y, transform.position.z);
            if (transform.position.x > newPos.x)
            {
                transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    public void Update()
    {
        if (lastLevel != currentLevel)
        {
            moveTo(currentLevel);
        }
    }

    public void moveTo(int level)
    {
        lastLevel = level;
        currentLevel = level;
        var newCamPos = Camera.main.ViewportToWorldPoint(new Vector2(0.25f + level - 1, .5f));
        StartCoroutine(TransitionToNewLevel(newCamPos));
    }
}
