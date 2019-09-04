using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAdjuster : MonoBehaviour
{
    // amount by which each button press changes the position by 
    public float increment = 0.01f;

    // keys on the keyboard we wish to use for adjustinsg
    public KeyCode upKey;
    public KeyCode downKey;

    void Start()
    {
        if (PlayerPrefs.HasKey("experiment_height"))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = PlayerPrefs.GetFloat("experiment_height");
            transform.position = newPosition;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            Vector3 newPosition = transform.position + Vector3.up * increment;
            transform.position = newPosition;
            PlayerPrefs.SetFloat("experiment_height", transform.position.y);
        }

        if (Input.GetKeyDown(downKey))
        {
            Vector3 newPosition = transform.position + Vector3.down * increment;
            transform.position = newPosition;
            PlayerPrefs.SetFloat("experiment_height", transform.position.y);
        }
    }
}
