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
    private int attackDamage = 100;

    public float dirX;
    /*public float X;
    public float Y;*/

    

    void Update()
    {
        /*Vector3 scale = transform.localScale;


        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else if (dirX < 0)
        {
            scale.x = Mathf.Abs(scale.x);



        }
        attackPoint.localScale = scale;*/



        /*if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            attack();
            canAttack = false;
            StartCoroutine(attackCoolDown());

        }*/






    }
    void attack()
    {
        animator.SetTrigger("Attack");
        
        Collider2D[] hitEnemies  = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Collider2D[] hitEnemies  = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(X,Y), enemyLayers);

        Debug.Log("I AM HITTING THE CRAB HERE");
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
