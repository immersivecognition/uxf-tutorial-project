using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class FeedbackController : MonoBehaviour
{
    // we don't need a reference to the Session here because we are supplied a reference to the trial by the event
    // we only need a reference if we are doing something TO the session, rather than reacting to an event

    // we do need a reference to the cursor copy since we have to enable and move it.
    public Transform cursorCopy;

    // reference to the AudioClip we want to play on hit.
    public AudioClip collectSound;


    // method to show the feedback. the On Trial End event will pass us the reference to the trial that has just completed
    public void Present(Trial endedTrial)
    {
        // get the results for this trial
        // we have to cast to types (using the name of the type in brackets)
        string outcome = (string) endedTrial.result["outcome"];
        if (outcome != "hit" & outcome != "miss") return; // early exit, dont do anything
        float angle = (float) endedTrial.result["angle"];     

        // calculate new position of cursor copy by rotating "angle" degrees about the y axis
        // relative to the forward position, and using radius of 0.2
        Vector3 newPosition = Quaternion.Euler(0, angle, 0) * (Vector3.forward * 0.2f);
        
        // don't change the height. 2D task
        newPosition.y = cursorCopy.position.y;

        // enable cursor copy and set its position
        cursorCopy.gameObject.SetActive(true);
        cursorCopy.position = newPosition;

        // if we hit, play our "collect" audio clip (copied code from TargetController)
        if (outcome == "hit")
        {
            // we will play it at the new cursorCopy location, 100% volume
            AudioSource.PlayClipAtPoint(collectSound, newPosition, 1.0f);
        }
    }   
}
