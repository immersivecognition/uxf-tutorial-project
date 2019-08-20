using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add the UXF namespace     
using UXF; // <-- new

public class TargetController : MonoBehaviour
{
    // reference to the UXF Session - so we can end the trial.
    public Session session; // <-- new

    // reference to the AudioClip we want to play on trigger enter.
    public AudioClip collectSound;

    void Start() // <-- new
    {
        // disable the whole GameObject immediately
        gameObject.SetActive(false); // <-- new
    }

    /// OnTriggerEnter is called when the Collider 'other' enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cursor")
        {
            // disable the whole GameObject
            gameObject.SetActive(false);

            // play the collect sound (at the same position as the target, 100% volume)
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 1.0f);

            // end current trial
            session.EndCurrentTrial(); // <-- new
        }
    }
}
