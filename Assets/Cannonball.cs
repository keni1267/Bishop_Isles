using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float speed = 5.0f;
    GameObject target;
    
    Rigidbody2D ball;

    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized*speed;
        ball.velocity = new Vector2(moveDir.x,moveDir.y);
        //Destroy(this.gameObject,2);
    }

}
