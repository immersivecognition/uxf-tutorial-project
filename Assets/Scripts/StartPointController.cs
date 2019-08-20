using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointController : MonoBehaviour
{
    /// OnTriggerEnter is called when the Collider 'other' enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A collider entered the trigger!");
    }

    /// OnTriggerExit is called when the Collider 'other' has stopped touching the trigger.
    void OnTriggerExit(Collider other)
    {      
        Debug.Log("A collider exited the trigger!");
    }
}
