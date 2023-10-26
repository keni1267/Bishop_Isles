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
    public void Setup()
    {
        GameObject object0 = new GameObject();
        object0.SetActive(true);
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
