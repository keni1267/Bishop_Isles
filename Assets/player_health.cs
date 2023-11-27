using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      //for now
using System.IO.Ports;
using System.Threading;
using System;


public class player_health : MonoBehaviour
{
    public float health;
    public float max_health;
    public Image HealthBar;
    private bool IsAlive;
    public Healthpickup pickup;

    public GameManagerScript gameManager;

    float lastfiretime;


    void Start()
    {
        max_health = health;
    }

    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(health / max_health, 0 ,1);
    }
    public void Damage(int amount){
        if(health > 0){
            health -= amount;                
            Debug.Log(health);
        }
         if(health <= 0){
            Destroy(gameObject);
            gameManager.gameOver();
            //SceneManager.LoadScene("GameOverScreen");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }

    }
    //the player is destroyed if it dies
       
   public void Heal(int healthRestore)
   {
        if(health > 0 && health < max_health)
        {
            health += healthRestore;
            Debug.Log(health);
            //Destroy(gameObject);
        }
   }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Trigger");
        //pickup.HealthRestoree();
        if(collider.gameObject.tag == "Healthpickup")
        {
            Debug.Log("pickup");
            Destroy(collider.gameObject);
            Heal(15);
            
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {

        if (Time.time - lastfiretime < 1) return;

        if (col.gameObject.tag.Equals("fire"))
        {
            Damage(25);
            
            lastfiretime = Time.time;

        }
    }

}
