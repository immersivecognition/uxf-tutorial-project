using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // reference to the AudioClip we want to play on trigger enter.
    public AudioClip collectSound;

    /// OnTriggerEnter is called when the Collider 'other' enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cursor")
        {
            // disable the whole GameObject
            gameObject.SetActive(false);

            // play the collect sound (at the same position as the target, 100% volume)
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 1.0f);
        }
    }
}
