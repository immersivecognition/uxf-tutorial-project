using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAdjuster : MonoBehaviour
{
    // amount by which each button press changes the height by 
    public float heightIncrement = 0.01f;

    // keys on the keyboard we wish to use for adjusting position
    public KeyCode upKey = KeyCode.F9;
    public KeyCode downKey = KeyCode.F10;
    public KeyCode recenter = KeyCode.F11;
    
    // used for calculating and applying position/rotation offsets
    [Tooltip("Assign to the Camera used within the camera rig.")]
    public Camera headCamera;
    [Tooltip("Assign to the VR camera rig.")]
    public Transform cameraRig;

    Vector3 targetFloorPosition;


    void Start()
    {
        // table height
        if (PlayerPrefs.HasKey("experiment_height"))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = PlayerPrefs.GetFloat("experiment_height");
            transform.position = newPosition;
        }

        // camerarig offset
        targetFloorPosition = cameraRig.position;

        if (PlayerPrefs.HasKey("camera_offset_x"))
        {
            if ((headCamera != null) && (cameraRig != null))
            {
                float yaw = PlayerPrefs.GetFloat("camera_offset_yaw");
                cameraRig.Rotate(0f, -yaw, 0f);

                float x = PlayerPrefs.GetFloat("camera_offset_x");
                float z = PlayerPrefs.GetFloat("camera_offset_z");
                cameraRig.position = new Vector3(-x, 0, -z);
            }
            else
            {
                Debug.Log("Error: References to headCamera and/or cameraRig not found!");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(upKey)) OffsetHeight(heightIncrement);
        if (Input.GetKeyDown(downKey)) OffsetHeight(-heightIncrement);
        if (Input.GetKeyDown(recenter)) ResetSeatedPos();
    }

    void OffsetHeight(float amount)
    {
        Vector3 newPosition = transform.position + Vector3.up * amount;
        transform.position = newPosition;
        PlayerPrefs.SetFloat("experiment_height", transform.position.y);
    }

    void ResetSeatedPos()
    {
        if ((headCamera != null) && (cameraRig != null))
        {
            //ROTATION
            // Get current head heading in scene (y-only, to avoid tilting the floor)
            float yaw = headCamera.transform.eulerAngles.y;
            // Now rotate CameraRig in opposite direction to compensate
            cameraRig.Rotate(0f, -yaw, 0f);
 
            //POSITION
            // Calculate postional offset between CameraRig and Camera
            Vector3 offsetPos = headCamera.transform.position - cameraRig.position;
            // Do not modify height
            offsetPos.y = 0;
            // Reposition CameraRig to target minus offset
            cameraRig.position = targetFloorPosition - offsetPos;

            // Store in PlayerPrefs
            PlayerPrefs.SetFloat("camera_offset_yaw", yaw);
            PlayerPrefs.SetFloat("camera_offset_x", offsetPos.x);
            PlayerPrefs.SetFloat("camera_offset_z", offsetPos.z);
        }
        else    
        {
            Debug.Log("Error: References to headCamera and/or cameraRig not found!");
        }
    }
}
