
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : MonoBehaviour
{
    public Animator animator;
    private int maxHealth = 150;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        Debug.Log(currentHealth);
        Debug.Log("Pirana HITTTTT");
        //play hurt animation


        if(currentHealth <= 0)
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
        //GetComponent<Piranha_AI>().enabled = false;
        GetComponent<Piranha_AI>().enabled = false;
        this.enabled= false;
    }

}