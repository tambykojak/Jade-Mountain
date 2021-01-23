using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float boosterForce = 3f;
    [SerializeField] private float rotationSpeed = 30f;
    
    private bool isBoosterOn = false;
    private float rotationDirection = 0f;

    void Start()
    {
            
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) isBoosterOn = true;
        else isBoosterOn = false;
        rotationDirection = Input.GetAxisRaw("Horizontal");
    }

    public void FixedUpdate()
    {
        if (rotationDirection != 0) Rotate(); 
        if (isBoosterOn) ApplyForce();
    }

    private void Rotate()
    {
        float rotationAmount = -rotationDirection * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
    }

    private void ApplyForce()
    {
        float x = Mathf.Cos(transform.rotation.z * Mathf.PI / 180) * boosterForce;
        float y = Mathf.Sin(transform.rotation.z * Mathf.PI / 180) * boosterForce;

        rb.AddForce(new Vector2(x, y));
    }

    public void OnDrawGizmos()
    {
Gizmos.Draw
    }
}
