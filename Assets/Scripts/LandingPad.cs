using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPad : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(NextLevel(collision.gameObject));
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator NextLevel(GameObject gameObject)
    {
        // There is some weird collision bug going on that's easier to avoid if we just wait a second.
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<PlayerCollision>().NextLevel();
    }
}
