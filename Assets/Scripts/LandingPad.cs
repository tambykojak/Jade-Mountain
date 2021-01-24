using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPad : MonoBehaviour
{
    [SerializeField] private AudioSource levelComplete;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelComplete.Play();
            GameObject.Find("Game Manager").GetComponent<GameManager>().nextLevel();
        }
    }
}
