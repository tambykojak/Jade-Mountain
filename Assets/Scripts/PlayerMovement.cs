using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float boosterForce = 3f;
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float fuelConsumptionPerSecond = 10f;
    [SerializeField] private GameObject boosterFlame;
    [SerializeField] private AudioSource audioSource;

    private bool isBoosterOn = false;
    private float rotationDirection = 0f;
    private Fuel fuel;
    private bool canRotate = false;

    void Start()
    {
        fuel = GetComponent<Fuel>();
    }

    private void Update()
    {
        ProcessInput();

        if (isBoosterOn && CanBoost())
        {
            boosterFlame.SetActive(true);
            audioSource.enabled = true;
        }
        else
        {
            boosterFlame.SetActive(false);
            audioSource.enabled = false;
        }
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) isBoosterOn = true;
        else isBoosterOn = false;
        rotationDirection = Input.GetAxisRaw("Horizontal");
    }

    public void FixedUpdate()
    {
        if (rotationDirection != 0 && canRotate) Rotate();
        if (isBoosterOn && CanBoost())
        {
            ApplyForce();
            if (fuel != null) fuel.ConsumeFuel(fuelConsumptionPerSecond * Time.fixedDeltaTime);
        }
    }

    private bool CanBoost()
    {
        if (fuel != null) return fuel.HasFuel();
        return true;
    }

    private void Rotate()
    {
        float rotationAmount = -rotationDirection * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platforms")) canRotate = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platforms")) canRotate = false;
    }

    private void ApplyForce()
    {
        float angle = transform.rotation.eulerAngles.z % 360;
        if (angle > 0) angle = 360 - angle;
        else angle *= -1;
        angle += 90;
        float x = Mathf.Cos(angle * Mathf.PI / 180) * boosterForce;
        float y = Mathf.Sin(angle * Mathf.PI / 180) * boosterForce;
        rb.AddForce(new Vector2(-x, y));
    }
}
