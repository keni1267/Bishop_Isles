using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Threading;
using System;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class projectileDmg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Projectile"))
        {

            //GetComponent<Bishop_Crab>().TakeDamage(200);
            //Debug.Log("kjsdnsjkdnsdjk");
            Bishop_Crab bishopCrab = GetComponent<Bishop_Crab>();
            if (bishopCrab != null)
            {
                bishopCrab.TakeDamage(25);
                Debug.Log("Hit Bishop_Crab");
            }

            // Check for BossHealth component
            BossHealth bossHealth = GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(15);
                Debug.Log("Hit BossHealth");
            }

            Piranha piranha = GetComponent<Piranha>();
            if (piranha != null)
            {
                piranha.TakeDamage(25);
                Debug.Log("Hit BossHealth");
            }
        }
    }
}
