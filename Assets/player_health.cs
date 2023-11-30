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
    public Image Lobster;
    public Image Crab;
    public Image Krill;
    private bool IsAlive;
    public Healthpickup pickup;

    public GameManagerScript gameManager;

    float lastfiretime;

    [SerializeField] private AudioSource hurt_sound;
    [SerializeField] private AudioSource died_sound;
    [SerializeField] private AudioSource heal_sound;


    void Start()
    {
        max_health = health;
        Lobster.gameObject.SetActive(true);
        Crab.gameObject.SetActive(false);
        Krill.gameObject.SetActive(false);
    }

    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(health / max_health, 0 ,1);
        if(health < 70 && health > 40){
            Lobster.gameObject.SetActive(false);
            Crab.gameObject.SetActive(true);
        }
        if(health <= 40){
            //Lobster.gameObject.SetActive(false);
            Crab.gameObject.SetActive(false);
            Krill.gameObject.SetActive(true);
        }
  

    }

    public void Damage(int amount){
        if(health > 0 && gameManager.ntouch == false){
            health -= amount;
            Debug.Log(health);
            Debug.Log(amount);
            //Debug.Log(health);
        }
         if(health <= 0){
            if (!died_sound.isPlaying)
            {
                died_sound.Play();

            }
            gameManager.gameOver();
            Debug.Log("Dead");
            //Destroy(gameObject);
            //gameManager.gameOver();
            //SceneManager.LoadScene("GameOverScreen");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
        if (!hurt_sound.isPlaying)
        {
            hurt_sound.Play();
            
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
        if (!heal_sound.isPlaying)
        {
            heal_sound.Play();

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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("shock"))
        {
            Damage(15);

        }

        if (col.gameObject.tag.Equals("slice"))
        {
            Damage(10);
        }

    }



}
