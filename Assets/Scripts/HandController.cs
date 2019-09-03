using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform rightHand;

    void Update()
    {
        Vector3 handPos = rightHand.position;
        handPos.y = transform.position.y; // lock to current Y position
        transform.position = handPos;
    }
}
