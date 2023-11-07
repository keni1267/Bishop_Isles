using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Threading;
using System;
using UnityEngine.UI;
public class shootscript : MonoBehaviour
{
   
    public Transform Spear;

    Vector2 direction;
    public GameObject Projectile;

    public float ProjectileSpeed;

    public Transform ShootPoint;

    public float fireRate;
    float ReadyForNextShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    direction = mousePos - (Vector2)Spear.position;
    //    FaceMouse();

    //    if (Input.GetMouseButton(1))
    //    {
    //        if(Time.time > ReadyForNextShot)
    //        {
    //            ReadyForNextShot = Time.time + 1 / fireRate;
    //            shoot();
    //        }

            
    //    }
    }

    void FaceMouse()
    {
        Spear.transform.right = direction;

    }
    void shoot()
    {
        GameObject spearIns = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        spearIns.GetComponent<Rigidbody2D>().AddForce(spearIns.transform.right * ProjectileSpeed);
        
       
        Destroy(spearIns, (float)0.3);
    }
}
