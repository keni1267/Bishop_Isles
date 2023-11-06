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
<<<<<<< HEAD
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
=======
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
>>>>>>> 4afdf7baf213cb71333b03b63b083b642a22b8ee
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        // if(gameOverUI.activeInHierarchy)
        // {
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.None;
        // }
        // else
        // {
        //     Cursor.visible = false;
        //     Cursor.lockState = CursorLockMode.Locked;
        // }
=======
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
>>>>>>> 4afdf7baf213cb71333b03b63b083b642a22b8ee
    }
    public void gameOver()
    {
        //GameObject object0 = new GameObject();
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
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
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
}
