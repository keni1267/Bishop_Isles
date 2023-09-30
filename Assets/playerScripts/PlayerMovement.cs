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

    private float timebtwAttack;
    public float startTimeBtwAttack;

    [SerializeField] private AudioSource running_sound;

    //[SerializeField] private Transform characterTransform;

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
        //att = Input.GetKey(KeyCode.H);

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        
        
        

        UpdateAnimationState();

    }
        
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            
            state = MovementState.running;
            if(!running_sound.isPlaying)
            {
                running_sound.Play();
            }
            //characterTransform.localScale = new Vector3(1f, 1f, 1f);
            sprite.flipX = false;
            

        }
        else if (dirX < 0f)
        {
            ;
            state = MovementState.running;
            if (!running_sound.isPlaying)
            {
                running_sound.Play();
            }
            //characterTransform.localScale = new Vector3(-1f, 1f, 1f);
            sprite.flipX = true;
            

        }
        else
        {
            running_sound.Stop();
            state = MovementState.idle;
            //characterTransform.localScale = new Vector3(1f, 1f, 1f);

        }
      
        anim.SetInteger("state", (int)state);
        

     


            

    }

}
