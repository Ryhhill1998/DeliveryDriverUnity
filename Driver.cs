using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 25f;

    bool movingForward = true;

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // check if driver is reversing and store true/false in movingForward
        if (moveAmount < 0) 
            movingForward = false;
        else 
            movingForward = true;

        transform.Translate(0, moveAmount, 0);

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        if (!movingForward) steerAmount *= -1; // reverse steering direction if car is reversing
        transform.Rotate(0, 0, -steerAmount);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        // decrease speed of car after collision
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            // increase speed of car after driving over boost
            moveSpeed = boostSpeed;
        }
    }
}
