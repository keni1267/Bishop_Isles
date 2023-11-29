using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_walk : StateMachineBehaviour
{
    public float speed = 4.0f;
    public float attackRange = 10000f;
    Transform player;
    Rigidbody2D rb;
    boss boss;
    public GameObject Projectile;
    Transform ShootPoint;
    Transform lsp;
    private MonoBehaviour monoBehaviour;
    float ready;
    private float firerate = 1;
    float delay; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //ShootPoint = GameObject.FindGameObjectWithTag("BOSS").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<boss>();
        monoBehaviour = boss;
        //delay = stateInfo.length - 55.0f;
        //.StartCoroutine(DelayedShockWave(delay));






    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        /*if(1f <= Vector2.Distance(player.position, rb.position) <= 4f)
        {
            animator.SetTrigger("Attack");

        }*/
        /*if (4f <= Vector2.Distance(player.position, rb.position) && Vector2.Distance(player.position, rb.position) <= 7f)
        {
            
            animator.SetTrigger("Attack");
            sendShockWave();
        }*/
        if (5f <= Vector2.Distance(player.position, rb.position) && Vector2.Distance(player.position, rb.position) <= 8f)
        {
            

            animator.SetTrigger("Attack");

            
            /*if (Time.time > ready)
            {
                ready = Time.time + 1 / firerate;
                monoBehaviour.StartCoroutine(DelayedShockWave(0.1f));
                


            }*/
            
            
        }



    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    /*void sendShockWave()
    {
        //yield return new WaitForSeconds(delay);

        ShootPoint = GameObject.FindGameObjectWithTag("right").transform;
        lsp = GameObject.FindGameObjectWithTag("left").transform;
        GameObject rspearIns = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        GameObject lspearIns = Instantiate(Projectile, lsp.position, lsp.rotation);
        lspearIns.transform.localScale = new Vector3(-1f, 1f, 1f);
        rspearIns.GetComponent<Rigidbody2D>().AddForce(rspearIns.transform.right * 900);
        lspearIns.GetComponent<Rigidbody2D>().AddForce(lspearIns.transform.right * -900);


        Destroy(rspearIns, (float)0.9);
        Destroy(lspearIns, (float)0.9);
    }*/
    IEnumerator DelayedShockWave(float delay)
    {
        yield return new WaitForSeconds(delay);

        ShootPoint = GameObject.FindGameObjectWithTag("right").transform;
        lsp = GameObject.FindGameObjectWithTag("left").transform;
        GameObject rspearIns = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        GameObject lspearIns = Instantiate(Projectile, lsp.position, lsp.rotation);
        lspearIns.transform.localScale = new Vector3(-.65f, .57f, 1f);
        rspearIns.GetComponent<Rigidbody2D>().AddForce(rspearIns.transform.right * 800);
        lspearIns.GetComponent<Rigidbody2D>().AddForce(lspearIns.transform.right * -800);

        Destroy(rspearIns, 0.9f);
        Destroy(lspearIns, 0.9f);
    }

    void sendShockWave()
    {
        // Use StartCoroutine to start the coroutine
        monoBehaviour.StartCoroutine(DelayedShockWave(10.0f));
    }



}
