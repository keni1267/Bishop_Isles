using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textScript : MonoBehaviour
{
    /*public GameObject diaPanel;
    public Text diatext;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject button;
    public bool inConversation = false;

    void Update()
    {

        *//*if (playerIsClose && !inConversation)
        {
            
            StartConversation();
        }*//*
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {

            if (diaPanel.activeInHierarchy)
            {
                zeroText();


            }
            else
            {
                diaPanel.SetActive(true);
                StartCoroutine(Typing());


            }

        }
        if (diatext.text == dialogue[index])
        {
            button.SetActive(true);
        }



    }
    void StartConversation()
    {
        inConversation = true;
        diaPanel.SetActive(true);
        StartCoroutine(Typing());
    }


    public void zeroText()
    {
        diatext.text = "";
        index = 0;
        diaPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            diatext.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }
        button.SetActive(true);

    }
    public void NextLine()
    {
        button.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            diatext.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            zeroText();
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("2");

        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }*/
    //////////////////////////////////////////////////////////////////////
    ///
    public Text diatext;
    public GameObject diaPanel;
    public GameObject button;

    public string[] dialogue;
    private int index = 0;
    public float wordSpeed = 0.1f;
    private bool playerIsClose = false;
    private bool inConversation = false; // Added a flag for conversation state
    public bool firstTime = true;
    void Update()
    {
        if (firstTime == true)
        {
            this.enabled= false;
            StartCoroutine(ExecuteAfterDelay(20f));
            firstTime= false;

        }

        if (playerIsClose && !inConversation)
        {
            StartConversation();
        }

       /* if (inConversation && Input.GetKeyDown(KeyCode.E))
        {
            NextLine();

        }*/

        if (index == 4)
        {
            this.enabled = false;
        }
    }

    IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.enabled = true;
        // Code to execute after the delay
        Debug.Log("10 seconds have passed!");
    }

    void StartConversation()
    {
        inConversation = true;
        diaPanel.SetActive(true);
        StartCoroutine(Typing());
    }

    public void zeroText()
    {
        diatext.text = "";
        index = 0;
        diaPanel.SetActive(false);
        inConversation = false;
        //this.enabled = false;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            diatext.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        button.SetActive(true);
    }

    public void NextLine()
    {
        button.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            diatext.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /* public Text diatext;
     public GameObject diaPanel;
     public GameObject button;

     public string[] dialogue;
     private int index = 0;
     public float wordSpeed = 0.1f;
     private bool playerIsClose = false;
     private bool inConversation = false;

     void Update()
     {
         if (playerIsClose && !inConversation)
         {
             StartConversation();
         }

         if (inConversation && Input.GetKeyDown(KeyCode.E))
         {
             NextLine();
         }
     }

     void StartConversation()
     {
         inConversation = true;
         diaPanel.SetActive(true);
         StartCoroutine(Typing());
     }

     public void zeroText()
     {
         diatext.text = "";
         index = 0;
         diaPanel.SetActive(false);
         inConversation = false;
     }

     IEnumerator Typing()
     {
         foreach (char letter in dialogue[index].ToCharArray())
         {
             diatext.text += letter;
             yield return new WaitForSeconds(wordSpeed);
         }

         if (index == dialogue.Length - 1)
         {
             // Close the panel when all text has been read
             ClosePanel();
         }
         else
         {
             button.SetActive(true);
         }
     }

     public void NextLine()
     {
         button.SetActive(false);
         if (index < dialogue.Length - 1)
         {
             index++;
             diatext.text = "";
             StartCoroutine(Typing());
         }
         else
         {
             ClosePanel();
         }
     }

     void ClosePanel()
     {
         diaPanel.SetActive(false);
         inConversation = false;
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Player"))
         {
             playerIsClose = true;
         }
     }

     private void OnTriggerExit2D(Collider2D other)
     {
         if (other.CompareTag("Player"))
         {
             playerIsClose = false;
             zeroText();
         }
     }*/

}

