using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour {
    public void Scene2() {
        SceneManager.LoadScene("Level_2");
        //Cursor.lockState = CursorLockMode.Locked;
    }
}

