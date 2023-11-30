using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Threading;
using System;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenuScreen;
    void Start()
    {
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            /*Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;*/
        }
    }
    public void gameOver()
    {
        //GameObject object0 = new GameObject();
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("GAME MANAGER RESTART");
        Debug.Log("Restart");
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Main Menu");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
        Debug.Log("PAUSE BUTTON LVL 2 HOPEFULLY");

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Debug.Log("GAME MANAGER RESUME");
        pauseMenuScreen.SetActive(false);
        
    }
}
