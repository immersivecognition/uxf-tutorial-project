using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TaskAreaController : MonoBehaviour
{
    public Session session;
    public Transform hiddenCursor;

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Cursor" & session.InTrial)
        {
            Vector3 cursorPos = other.transform.position;
            cursorPos.y = 0; // strip the y coordinate - we want to measure a 2D angle (XZ plane)
            Vector3 targetDir = Vector3.forward; // change this if we move the target

            // calculate the angle from the target (forward direction) to the cursor (about the up axis)
            float angle = Vector3.SignedAngle(targetDir, cursorPos, Vector3.up);
            // calculate the angle from the target to the HiddenCursor (our ACTUAL hand position)
            float handAngle = Vector3.SignedAngle(targetDir, hiddenCursor.position, Vector3.up);

            // store the result in the current trial - this will then be saved in the trial_results csv
            session.CurrentTrial.result["angle"] = angle;
            session.CurrentTrial.result["hand_angle"] = handAngle;

            // hit if we are within the threshold
            float threshold = 6.0f;
            bool hit = Mathf.Abs(angle) < threshold;
            session.CurrentTrial.result["outcome"] = hit ? "hit" : "miss";

            // end current trial
            session.EndCurrentTrial();
        }
    }
}