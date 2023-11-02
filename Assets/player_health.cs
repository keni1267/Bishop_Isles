using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      //for now


public class player_health : MonoBehaviour
{
    public float health;
    public float max_health;
    public Image HealthBar;

  


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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }

    }
    //the player is destroyed if it dies
       
   

}
