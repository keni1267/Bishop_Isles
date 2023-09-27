using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    private float dirX = 0f;
    private bool att = false;

    [SerializeField]
    private float moveSpeed = 7f;
    [SerializeField]
    private float jumpForce = 14f;

    private SpriteRenderer sprite;


    private enum MovementState
    {
        idle,
        running,
        attacking,
        jumping
    }

    

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        att = Input.GetMouseButtonDown(0);
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        

        UpdateAnimationState();

    }
        
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;

        }
        else
        {
            state = MovementState.idle;
            
        }
        if (rb.velocity.y > .1f)
        {
            
            state = MovementState.attacking;
            Debug.Log("Attack triggered");

        }
      

        anim.SetInteger("state", (int)state);

    }

}
