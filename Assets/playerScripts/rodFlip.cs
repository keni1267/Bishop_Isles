using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodFlip : MonoBehaviour
{
    public float dirx;
    // Start is called before the first frame update
    public GameObject fishermen;
    GameObject ap;
   


    void Start()
    {
         ap = fishermen.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float  fishermanX = fishermen.transform.position.x;

        dirx = Input.GetAxisRaw("Horizontal");
        //get fisherman transform position 
        if (dirx == 1)
        {
            
            ap.transform.position = new Vector3(fishermanX+1, transform.position.y, transform.position.z); //change 1 to fisherman x + 1

        }
        else if(dirx==-1)
        {
            
            ap.transform.position = new Vector3(fishermanX-1, transform.position.y, transform.position.z); //change -1 to fisherman x - 1


        }
        else
        {
            
            ap.transform.position = new Vector3(ap.transform.position.x, transform.position.y, transform.position.z);
        }

    }
}
