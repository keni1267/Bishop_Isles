using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Animator animator;
    public Image healthbar;
    
    float maxHealth = 200;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            //Die();
            animator.SetBool("isDead", true);
            //GetComponent<BoxCollider2D>().enabled = false;
            //GetComponent<SpriteRenderer>().enabled = false;
            //this.enabled = false;
            //animator.enabled= false;
            //this.enabled = false;

        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.fillAmount = currentHealth / 200f;
        Debug.Log(currentHealth);
        //animator.SetTrigger("Hurt");
        //play hurt animation


        /*if (currentHealth <= 0)
        {
            //Die();
            animator.SetBool("isDead", true);
            //GetComponent<BoxCollider2D>().enabled = false;
            //GetComponent<SpriteRenderer>().enabled = false;
            this.enabled= false;

        }*/
    }

    public void Die()
    {
        animator.enabled = false;

    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

}
