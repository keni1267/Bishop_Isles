using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crab_AI : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float attack_speed;
    public float lineOfSite;
    public float attackRange;
    public float timer; //attack cooldown
    public PlayerMovement playerHealth;   //accesing script needed for player damage
    public int damage;

    #endregion
    

    #region Private Variables
    private int waypointIndex = 0;
    private Transform player;
    [SerializeField]
    private Transform[] waypoints;
    private Animator anim;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    private bool hasAttacked = false; //so it only gets damage once

    #endregion


   void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;   //position between waypoints
        player = GameObject.FindGameObjectWithTag("Player").transform;  //fisherman has tag player
        playerHealth = player.GetComponent<PlayerMovement>(); //gets player health from player object
      
    }

    void Update()
    {
        float distance_from_player = Vector2.Distance(player.position,transform.position);  //checks distance from enemy and fisherman
        if (distance_from_player < lineOfSite && distance_from_player > attackRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position,attack_speed*Time.deltaTime);  //moves towards player
            if(hasAttacked == false){
                Attack();
                hasAttacked = true;
            }
        }
        else if(distance_from_player <= attackRange && cooling == false && hasAttacked == false){
            Attack();
            hasAttacked = true;
        }
       if(cooling){
            Cooldown();
            anim.SetBool("Attack",false);
        }
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

    void Attack(){
        timer = intTimer;       //reset timer when player in attack range
        attackMode = true;
       // anim.SetBool("Attack",true);
        GetComponent<Animator>().SetTrigger("Attack"); // same as anim.SetBool("Attack", true) but it doesnt glitch as much
/*
        if (attackMode && playerHealth != null) 
        { 

        }*/
           //playerHealth.Damage(damage);
        
    
    }
    void Cooldown(){
        timer -= Time.deltaTime;
        if(timer <= 0 && cooling && attackMode){
            cooling = false;
            timer = intTimer;
            hasAttacked = false;
        }
    }

   public void TriggerCooling(){
        cooling = true;
    }
}

//https://www.youtube.com/watch?v=lHLZxd0O6XY
//https://www.youtube.com/watch?v=waj6i9cQ6rM