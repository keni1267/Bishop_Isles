using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    Transform ShootPoint;
    Transform lsp;
    public GameObject Projectile;
    float ready;
    //private MonoBehaviour monoBehaviour = animator.GetComponent<boss>();
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    public void ShockWave()
    {
        //yield return new WaitForSeconds(delay);

        ShootPoint = GameObject.FindGameObjectWithTag("right").transform;
        lsp = GameObject.FindGameObjectWithTag("left").transform;
        GameObject rspearIns = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        GameObject lspearIns = Instantiate(Projectile, lsp.position, lsp.rotation);
        lspearIns.transform.localScale = new Vector3(-.65f, .57f, 1f);
        rspearIns.GetComponent<Rigidbody2D>().AddForce(rspearIns.transform.right * 800);
        lspearIns.GetComponent<Rigidbody2D>().AddForce(lspearIns.transform.right * -800);

        Destroy(rspearIns, 0.9f);
        Destroy(lspearIns, 0.9f);
    }

    public void sendShockWave()
    {
        //if (Time.time > ready)
        //{
        ready = Time.time + 1 / 1;
        ShockWave();
        Debug.Log("Shockwave");



        //}
    }

    /*void sendShockWave()
    {
        // Use StartCoroutine to start the coroutine
        monoBehaviour.StartCoroutine(DelayedShockWave(10.0f));
    }*/


}
