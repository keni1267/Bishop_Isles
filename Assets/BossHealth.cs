using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Animator animator;
    public Image healthbar;
    [SerializeField] private AudioSource bossWalk;
    [SerializeField] private AudioSource bossWalk2;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource stompSound;
    [SerializeField] private AudioSource energySlash;
    float maxHealth = 200;
    float currentHealth;
    public bool isInvulnerable = false;
    public Canvas healthCanvas;
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
        if (isInvulnerable)
        {
            return;
        }
        currentHealth -= damage;
        animator.SetTrigger("isHit");
        healthbar.fillAmount = currentHealth / 200f;
        Debug.Log(damage);
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
        healthCanvas.enabled = false;
        animator.enabled = false;

    }

    public void playWalkSound()
    {
        if (!bossWalk.isPlaying)
        {
            bossWalk.Play();
        }
    }

    public void playWalkSound2()
    {
        if (!bossWalk2.isPlaying)
        {
          bossWalk2.Play();
        }
    }

    public void playDamageSound()
    {
        if(!damageSound.isPlaying)
        {
            damageSound.Play();
        }

    }

    public void playStompAttackSound()
    {
        if (!stompSound.isPlaying)
        {
            stompSound.Play();
        }
    }

    public void playenergySlashSound()
    {
        if (!energySlash.isPlaying)
        {
            energySlash.Play();
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

}
