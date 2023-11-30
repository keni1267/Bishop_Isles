using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string Scene;
    void Start()
    {

    }

    public void OpenScene()
    {
        SceneManager.LoadScene(Scene);
    }
}
