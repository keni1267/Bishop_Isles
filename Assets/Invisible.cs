using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    Renderer rend;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
