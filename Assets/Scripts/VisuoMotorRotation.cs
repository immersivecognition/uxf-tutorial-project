using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class VisuoMotorRotation : MonoBehaviour
{
    public Session session;
    public Transform hiddenCursor;
    public Transform startPoint;
    
    MeshRenderer cursorMR;
    float vmrAngle = 0f;
    bool clamped = false;

    void Awake()
    {
        // get the mesh renderer attached to this component
        // could also be done with public variable
        cursorMR = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // we don't want to have any intervention when moving back to the start point
        // so if we aren't in a trial let's just show the cursor normally
        if (!session.hasInitialised | !session.InTrial)
        {
            transform.position = hiddenCursor.position;
            return; // exit the function early
        }

        if (clamped)
        {
            // calculate distance from center
            float dist = (hiddenCursor.position - startPoint.position).magnitude;
            // move towards target with calculated distance (i.e. with 0 error)
            transform.position = startPoint.position + Vector3.forward * dist;
        }
        else
        {
            // update the position of this object
            transform.position = hiddenCursor.position;
        }

        transform.RotateAround(startPoint.position, Vector3.up, vmrAngle);
    }

    // assign this function to run On Trial Begin
    public void UpdateSettings(Trial trial)
    {
        // use settings.Get*() to access settings (independent variables)
        vmrAngle = session.CurrentTrial.settings.GetFloat("vmr_angle");
        clamped = session.CurrentTrial.settings.GetBool("clamped_error");

        // enable/disable cursor mesh renderer as needed
        cursorMR.enabled = session.CurrentTrial.settings.GetBool("online_feedback");
    }
}
