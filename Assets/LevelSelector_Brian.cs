using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorBrian : MonoBehaviour {
    public void Level1() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Level2() {
        SceneManager.LoadScene("Level_2");
    }

    public void Level3() {
        SceneManager.LoadScene("Level_3");
    }
}
