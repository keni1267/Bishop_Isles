using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crab_AI : MonoBehaviour
{
    public float speed;
    public float attack_speed;
    public float lineOfSite;
    public float attackRange;
    private int waypointIndex = 0;
    public Animator animator;
    public float delay = 0.03f;
    private bool attackBlocked;
  
    private Transform player;
    [SerializeField]
    private Transform[] waypoints;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;   //position between waypoints
        player = GameObject.FindGameObjectWithTag("Player").transform;  //fisherman has tag player
    }

    void Update()
    {
        float distance_from_player = Vector2.Distance(player.position,transform.position);  //checks distance from enemy and fisherman
        if (distance_from_player < lineOfSite && distance_from_player > attackRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position,attack_speed*Time.deltaTime);  //moves towards player
            Attack();
        }
       // else if(distance_from_player <= attackRange)
            //Attack();
        else{
            Patrol();     //stable move
        }
    }

    private void OnDrawGizmosSelected()    //creates line of site
    {
        Gizmos.color = Color.blue; 
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }
    private void Patrol(){
        Transform wp = waypoints[waypointIndex];
        if(Vector2.Distance(transform.position, wp.position) < 0.01f){
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position,
               wp.position, speed* Time.deltaTime);
        }
    }
    public void Attack(){
        //if(attackBlocked)
           //return;
        animator.SetTrigger("Attack");
       // attackBlocked = true;
       // StartCoroutine(DelayAttack());
    }
    //private IEnumerator DelayAttack(){
        //yield return new WaitForSeconds(delay);
        //attackBlocked = false;
    //}
    

}
//https://www.youtube.com/watch?v=lHLZxd0O6XY