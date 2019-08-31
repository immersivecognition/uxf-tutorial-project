using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

// important! UI requires adding this namespace
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour
{   
    public Text instructions;

    void Awake()
    {
        instructions.text = ""; // no instructions until we start the session
    }

    // assign to On Session Begin event
    public void Present(Session session)
    {
        instructions.text = session.settings.GetString("instruction");
    }
}
