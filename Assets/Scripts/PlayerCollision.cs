using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float safeDegrees = 8f;
    [SerializeField] private Vector2 safeMaxVelocity = new Vector2(1.5f, 2f);
    [SerializeField] private AudioSource crashAudioSource;

    private Vector2 lastVelocity;

    public void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
            if (!IsAngleSafeForLanding() || !IsSpeedSafeForLanding())
            {
                crashAudioSource.Play();
                Destroy(gameObject);
            }
        }
    }

    private bool IsAngleSafeForLanding()
    {
        float angle = transform.rotation.eulerAngles.z % 360;
        if (angle > 0) angle = 360 - angle;
        else angle *= -1;
        bool safe = angle < safeDegrees || angle > 360 - safeDegrees;
        if (!safe) Debug.Log("Angle wasn't safe. Your angle was " + angle + ". A safe angle is greater than " + (360 - safeDegrees) + " (-" + safeDegrees + ") or less than " + safeDegrees + ".");
        return safe;
    }

    private bool IsSpeedSafeForLanding()
    {
        bool safe = Mathf.Abs(lastVelocity.x) <= safeMaxVelocity.x && Mathf.Abs(lastVelocity.y) <= safeMaxVelocity.y;
        if (!safe) Debug.Log("Velocity wasn't safe. Your velocity when colliding was " + lastVelocity + ". The max safe velocity is " + safeMaxVelocity);
        return safe;
    }
}
