using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class levelselection : MonoBehaviour
{

    public Button[] lvlButtons;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2) - 1;
        Debug.Log("jfklsdfm");
        for(int i = 0;i < lvlButtons.Length;i++)
        {
            if(i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
        
    }

    
}
