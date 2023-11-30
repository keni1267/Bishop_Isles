using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop_Crab : MonoBehaviour
{
    public Animator animator;
    private int maxHealth = 500;
    int currentHealth;
    [SerializeField] private AudioSource crabhurt_sound;

    void Start()
    {
        currentHealth = maxHealth;


    }

    public void TakeDamage(int damage)
    {

        
        currentHealth -= damage;
        Debug.Log(currentHealth);
        animator.SetTrigger("Hurt");
        //play hurt animation
        if (!crabhurt_sound.isPlaying)
        {
            crabhurt_sound.Play();
            //rod_attack_sound.Stop();
        }

        if (currentHealth <= 0)
        {
            Die();

        }
    }
    

    void Die()
    {
        //die animation
        Debug.Log("Enemy Die");
        animator.SetBool("isDead", true);
        //diable enemy


        GetComponent<BoxCollider2D>().enabled = false;
        //GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<Animator>().enabled = false;
        GetComponent<Crab_AI>().enabled = false;
        this.enabled= false;
    }

}

    
