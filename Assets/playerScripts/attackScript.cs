using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attackScript : MonoBehaviour
{
    private float attackCooldown = 1.0f;
    private bool canAttack = true;

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 5;

    public float dirX;
    /*public float X;
    public float Y;*/

    

    void Update()
    {
        
        
        dirX = Input.GetAxisRaw("Horizontal");
        /*if(dirX > 0)
        {
            attackPoint.position = new Vector3(1.06f, 1.81f, 0.02000046f);
        }
        else if( dirX < 0)
        {
            attackPoint.position = new Vector3(-1.06f, 1.81f, 0.02000046f);

        }*/

        

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {   
            attack();
            canAttack = false;
            StartCoroutine(attackCoolDown());
            
        }
            

        
        
        
        
    }
    void attack()
    {
        animator.SetTrigger("Attack");
        
        Collider2D[] hitEnemies  = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Collider2D[] hitEnemies  = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(X,Y), enemyLayers);


        foreach (Collider2D enemy in hitEnemies)
        {
            
          enemy.GetComponent<Bishop_Crab>().TakeDamage(attackDamage);
        }
        
          
    }

    IEnumerator attackCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint== null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        //Gizmos.DrawWireCube(attackPoint.position, new Vector3(X, Y, 1));
    }

    
}
