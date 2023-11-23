using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.IO.Ports;
using System.Threading;
using System;

public class Healthpickup : MonoBehaviour
{
    #region Public Variables
    public int healthRestore = 15;
    public player_health playerH;
    public float lineOfSite;
    public float attackRange;
    // Start is called before the first frame update
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
    private bool hasAttacked = false;

    #endregion
    
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;   //position between waypoints
        player = GameObject.FindGameObjectWithTag("Player").transform;  //fisherman has tag player
        playerH = player.GetComponent<player_health>(); //gets player health from player object
      
    }

    void Update()
    {
      //HealthRestoree();
      //float distance_from_player = Vector2.Distance(player.position,transform.position);
      // if( playerH.health < playerH.max_health)
      // {
        
      //   playerH.Heal(healthRestore);
      //   Destroy(gameObject);
      // }
    }
    void Awake()
    {
        playerH = FindObjectOfType<player_health>();
    }
    // void onTriggerEnter2D(Collider2D collision)
    // {
    //   if(playerH.health < playerH.max_health)
    //   {
    //     playerH.Heal(healthRestore);
    //     Destroy(gameObject);
    //   }
    // }

    public void HealthRestoree()
    {
      if(playerH.health < playerH.max_health)
      {
        
        playerH.Heal(healthRestore);
        Destroy(gameObject);
      }
    }
}
