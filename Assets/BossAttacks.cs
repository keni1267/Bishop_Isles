using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    Transform ShootPoint;
    Transform lsp;
    public GameObject Projectile;
    public GameObject sliceProjectile;
    public Transform mid;
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


    public void sliceAttack()
    {
        //yield return new WaitForSeconds(delay);

        ShootPoint = GameObject.FindGameObjectWithTag("sright").transform;
        lsp = GameObject.FindGameObjectWithTag("sleft").transform;
        mid = GameObject.FindGameObjectWithTag("middle").transform;
        GameObject rspearIns = Instantiate(sliceProjectile, ShootPoint.position, ShootPoint.rotation);
        GameObject lspearIns = Instantiate(sliceProjectile, lsp.position, lsp.rotation);
        //GameObject midSpear = Instantiate(sliceProjectile, mid.position, mid.rotation);
        rspearIns.transform.localScale = new Vector3(-.58f, .3f, 1f);
        lspearIns.transform.localScale = new Vector3(.58f, .3f, 1f);
        //midSpear.transform.localScale = new Vector3(.58f, .3f, 1f);
        rspearIns.GetComponent<Rigidbody2D>().AddForce(rspearIns.transform.right * 800);
        lspearIns.GetComponent<Rigidbody2D>().AddForce(lspearIns.transform.right * -800);
        //midSpear.GetComponent<Rigidbody2D>().AddForce(midSpear.transform.right * 800);

        Destroy(rspearIns, 0.2f);
        Destroy(lspearIns, 0.2f);
        //Destroy(midSpear, 0.9f);
    }

    public void sendSlice()
    {
        //if (Time.time > ready)
        //{
        ready = Time.time + 1 / 1;
        sliceAttack();
        Debug.Log("Shockwave");



        //}
    }

    /*void sendShockWave()
    {
        // Use StartCoroutine to start the coroutine
        monoBehaviour.StartCoroutine(DelayedShockWave(10.0f));
    }*/


}
