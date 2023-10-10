using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Threading;
using System;
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

    Thread _t2;
    bool connected =false;
    string inData="6\n";
    int last_movement=0;
    public static SerialPort our_controller = new SerialPort("/dev/cu.usbserial-0001",115200);


    //attack
     private float attackCooldown = 1.0f;
    private bool canAttack = true;

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;


    [SerializeField] private AudioSource running_sound;

    //[SerializeField] private Transform characterTransform;

    private enum MovementState
    {
        idle,
        running,
        attacking,
        jumping
    }

    

     void _func2(object obj)
    {
        //Debug.Log("IM HEREEE");
        connected =true;
        try{
        our_controller.Open();
        }
        catch
        {
            Debug.Log("NO CONNECTOR");
            connected=false;
        }
        if(connected)
        while (true)
        {
            try{
            inData = our_controller.ReadLine();
            if (inData.Length>3)
            inData="6\n";
            }
            catch{Debug.Log("NO CONNECTOR");
            break;}
            Debug.Log(inData);
        }

    }
    private void Start()
    {
       _t2 = new Thread(_func2);
       _t2.Start();


        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();



    }

    
    private void Update()
    {
 
        int controller =int.Parse(inData); 
        //att = Input.GetKey(KeyCode.H);

        bool something=false;
        //change int.Parse to compare to string in future
        if( controller== 7)
        {last_movement=7;
            dirX = 1;
            }
        else if(controller == 6)
        {last_movement=6;
            dirX = 0;
            }
        else if(controller == 4)
            {
            dirX = 0;
            last_movement=4;
            }
        else if(controller == 5)
        {
         last_movement=5;
            dirX = -1;
        }
        else if(controller == 8)
            something=true;
        else if(controller == 9)
            something=false;

        float dirX2 = Input.GetAxisRaw("Horizontal");
        
        if(dirX2!=0)
            dirX = dirX2;

       // Debug.log(dirX);
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        if ((Input.GetKeyDown(KeyCode.Mouse0) && canAttack)||(something && canAttack))
        {   
            attack();
            inData=last_movement.ToString()+"\n";
            canAttack = false;
            something=false;
            StartCoroutine(attackCoolDown());
            
        }
        if (Input.GetKeyDown(KeyCode.Space) || controller == 2) { 
            rb.velocity = new Vector2(rb.velocity.x, 14f);
            last_movement = 2;
            //Debug.Log(KeyCode.Space);
        }
        if(controller == 3){
            last_movement = 3;
            dirX = 0;
        }
        

        if (transform.position.y < -10)
        {
            gameOver();

        }

        
        

        UpdateAnimationState();

    }
    void attack()
    {
        animator.SetTrigger("Attack");
        
        Collider2D[] hitEnemies  = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Collider2D[] hitEnemies  = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(X,Y), enemyLayers);


        foreach (Collider2D enemy in hitEnemies)
        {
            
          enemy.GetComponent<Bishop_Crab>().TakeDamage(attackDamage);
        }
        
          
    }

    IEnumerator attackCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint== null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        //Gizmos.DrawWireCube(attackPoint.position, new Vector3(X, Y, 1));
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f )
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

    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
