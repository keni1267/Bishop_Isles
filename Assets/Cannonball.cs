using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float speed = 5.0f;
    public float fallSpeed = 0.005f; // Adjust this value for a slower fall

    Rigidbody2D ball;

    void Start()
    {
        ball = GetComponent<Rigidbody2D>();

        // Apply an initial velocity with a higher horizontal component
        Vector2 initialVelocity = new Vector2(1.0f, 0.1f) * speed; // Adjust the values for the desired trajectory
        ball.velocity = initialVelocity;
       // Destroy(gameObject,4f);
        // Uncomment the line below if you want to apply an initial force instead
        // ball.AddForce(initialVelocity, ForceMode2D.Impulse);
    }

    void Update()
    {
        // Apply gravity to make the bullet fall
        ball.velocity += Vector2.down * fallSpeed * Time.deltaTime;
    }
}
