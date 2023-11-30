using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackDialogueScript : MonoBehaviour {
    public Text diatext;
    public GameObject diaPanel;
    public GameObject button;

    public string[] dialogue;
    //private string[] dialogue; //Brian test
    private int index = 0;
    public float wordSpeed = 0.1f;
    private bool playerIsClose = false;
    private bool inConversation = false; // Added a flag for conversation state
    public bool firstTime = true;
    void Update() {
        if (firstTime == true) {
            this.enabled = false;
            StartCoroutine(ExecuteAfterDelay(1f));
            firstTime = false;

        }

        if (playerIsClose && !inConversation) {
            StartConversation();
        }

        if (index == 2) {
            this.enabled = false;
            //firstTime = true;
        }

    }

    IEnumerator ExecuteAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        this.enabled = true;
        // Code to execute after the delay
        Debug.Log("10 seconds have passed!");
    }

    void StartConversation() {
        inConversation = true;
        diaPanel.SetActive(true);
        StartCoroutine(Typing());
    }

    public void zeroText() {
        diatext.text = "";
        index = 0;
        diaPanel.SetActive(false);
        inConversation = false;
        //this.enabled = false;
    }

    IEnumerator Typing() {
        foreach (char letter in dialogue[index].ToCharArray()) {
            diatext.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        button.SetActive(true);
    }

    public void NextLine() {
        button.SetActive(false);
        if (index < dialogue.Length - 1) {
            index++;
            diatext.text = "";
            StartCoroutine(Typing());
        } else {
            zeroText();

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsClose = true;
            other.GetComponent<Animator>().enabled = false;
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Invoke("EnablePlayerMovement", 5f);
        }

    }

    private void EnablePlayerMovement() {
        // Find the Player object and enable the Animator and PlayerMovement components.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            Animator playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator != null) {
                playerAnimator.enabled = true;
            }

            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null) {
                playerMovement.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsClose = false;
            zeroText();
        }
    }

}