using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    /* private PlayableDirector playableDirector;
     private bool hasPlayed = false;

     private void Update()
     {
         playableDirector = GetComponent<PlayableDirector>();

         if (playableDirector != null && !hasPlayed)
         {
             playableDirector.Play();
             hasPlayed = true;
         }
     }*/
    private PlayableDirector playableDirector;

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();

        if (playableDirector != null)
        {
            // Play the PlayableDirector
            playableDirector.Play();

            // Subscribe to the Director's played event
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
        else
        {
            Debug.LogWarning("No PlayableDirector component found on this GameObject.");
        }
    }

    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        // This method will be called when the PlayableDirector stops

        // Unsubscribe from the event to avoid potential memory leaks
        director.stopped -= OnPlayableDirectorStopped;

        // Disable the PlayableDirector
        director.enabled = false;
    }
}
