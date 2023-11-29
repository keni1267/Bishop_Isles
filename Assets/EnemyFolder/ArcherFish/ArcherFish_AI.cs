using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherFish_AI : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float attack_speed;
    public float lineOfSite;
    public float attackRange;       //shooting range
    public float fireRate = 1f;
    public GameObject cannonball;
    public GameObject cannonball_parent;
    public float timer; //attack cooldown
    public player_health playerHealth;   //accesing script needed for player damage
    public int damage;
    #endregion

    #region Private Variables
    private int waypointIndex = 0;
    private Transform player;
    [SerializeField]
    private Transform[] waypoints;
    private Animator anim;
    private bool cooling;
    private float intTimer;
    private bool hasAttacked = false; //so it only gets damage once
    private float next_fireTime;
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
        playerHealth = player.GetComponent<player_health>(); //gets player health from player object
    }

    void Update()
    {
        float distance_from_player = Vector2.Distance(player.position, transform.position);

        if (distance_from_player < lineOfSite && distance_from_player > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, attack_speed * Time.deltaTime);
            // Your other logic for following the player
        }
        else if (distance_from_player <= attackRange && next_fireTime < Time.time && cooling == false && hasAttacked == false)
        {
            // Ensure that the enemy is ready to attack
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                Attack();
                Instantiate(cannonball, cannonball_parent.transform.position, Quaternion.identity);
                next_fireTime = Time.time + fireRate;
                hasAttacked = true;
            }
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
        else
        {
            Patrol();
        }
    }

    private void OnDrawGizmosSelected()    //creates line of site
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void Patrol()
    {
        Transform wp = waypoints[waypointIndex];
        if (Vector2.Distance(transform.position, wp.position) < 0.01f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
               wp.position, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;       //reset timer when player in attack range
        // anim.SetBool("Attack",true);
        GetComponent<Animator>().SetTrigger("Attack"); // same as anim.SetBool("Attack", true) but it doesnt glitch as much

        if (playerHealth != null)
            playerHealth.Damage(damage);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            cooling = false;
            timer = intTimer;
            hasAttacked = false;
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
