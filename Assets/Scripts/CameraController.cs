using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector3 targetPos;
    bool movingCamera = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (movingCamera == true)
        {
            //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime / 0.5f);
        }

        if (transform.position.x == targetPos.x)
        {
            movingCamera = false;
        }

    }

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

    public void moveTo(int level)
    {
        var newCamXPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f + level - 1, .5f));
        targetPos = newCamXPos;
        StartCoroutine(TransitionToNewLevel(newCamXPos));
    }

}
