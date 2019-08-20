using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add the UXF namespace
using UXF;

public class ExperimentGenerator : MonoBehaviour
{     
    public void Generate(Session session)
    {
        // generate a single block with 10 trials.
        int numTrials = 10;
        session.CreateBlock(numTrials);
    }
}