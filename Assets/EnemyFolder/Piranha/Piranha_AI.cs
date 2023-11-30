using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha_AI : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float attack_speed;
    public float lineOfSite;
    public float attackRange;
    public float timer; //attack cooldown
    public player_health playerHealth;   //accessing script needed for player damage
    public int damage;
    public Transform[] waypoints;
    #endregion

    #region Private Variables
    private int waypointIndex = 0;
    private Animator anim;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    private bool hasAttacked = false; //so it only gets damage once
    #endregion
    [SerializeField] private AudioSource fishattack_sound;

    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        transform.position = waypoints[waypointIndex].position; //position between waypoints
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<player_health>(); //gets player health from player object
    }

    void Update()
    {
        float distance_from_player = Vector2.Distance(playerHealth.transform.position, transform.position); //checks distance from enemy and fisherman
        if (distance_from_player < lineOfSite && distance_from_player > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerHealth.transform.position, attack_speed * Time.deltaTime); //moves towards player
            if (hasAttacked == false)
            {
                Attack();
                hasAttacked = true;
            }
        }
        else if (distance_from_player <= attackRange && cooling == false && hasAttacked == false)
        {
            Attack();
            hasAttacked = true;
        }
        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
        else
        {
            Patrol(); //stable move
        }
    }

    private void OnDrawGizmosSelected() //creates line of site
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void Patrol()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned for patrolling.");
            return;
        }

        Transform targetWaypoint = waypoints[waypointIndex];
        float horizontalMove = Mathf.Sign(targetWaypoint.position.x - transform.position.x);

        // Flip the enemy based on the movement direction
        if (horizontalMove > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalMove < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
            hasAttacked = false; //reset attack status when changing waypoint
        }
    }

    void Attack()
    {
        timer = intTimer; //reset timer when player in attack range
        attackMode = true;
        anim.SetTrigger("Attack"); // same as anim.SetBool("Attack", true) but it doesn't glitch as much
        if (!fishattack_sound.isPlaying)
        {
            fishattack_sound.Play();

        }
        if (attackMode && playerHealth != null)
            playerHealth.Damage(damage);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
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
