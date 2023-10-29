using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Threading;
using System;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    void Start()
    {

    }

    void Update()
    {

    }
    public void gameOver()
    {
        //GameObject object0 = new GameObject();
        gameOverUI.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene*");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
