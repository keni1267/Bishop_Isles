using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Button : MonoBehaviour {
    public void Level3() {
        SceneManager.LoadScene("Level_3");
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
