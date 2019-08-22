using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class SetupNextTrial : MonoBehaviour
{
    public MeshRenderer cursorMR;
    public GameObject cursorCopy;
    public GameObject startPoint;

    public void DelayedSetup()
    {
        StartCoroutine(SetupSequence());
    }

    IEnumerator SetupSequence()
    {
        yield return new WaitForSeconds(0.5f);

        // note: .enabled is a property of *components*
        //       .SetActive() is a method of GameObjects

        cursorMR.enabled = true;
        cursorCopy.SetActive(false);
        startPoint.SetActive(true);
    }

}
