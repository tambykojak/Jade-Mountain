using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TransitionToNewLevel(Vector3 newPos)
    {

        float diff = Mathf.Abs(transform.position.x - newPos.x)/100;
        if (newPos.x < transform.position.x)
        {
            diff = -diff;
        }

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
        var newCamPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f + level - 1, .5f));
        StartCoroutine(TransitionToNewLevel(newCamPos));
    }

}
