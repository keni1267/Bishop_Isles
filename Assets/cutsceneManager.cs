using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayableDirector playableDirector;
    private bool hasPlayed = false;

    private void Update()
    {
        playableDirector = GetComponent<PlayableDirector>();

        if (playableDirector != null && !hasPlayed)
        {
            playableDirector.Play();
            hasPlayed = true;
        }
    }
}
