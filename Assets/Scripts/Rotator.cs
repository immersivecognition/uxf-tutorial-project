using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 speed;

    void Update()
    {
        transform.eulerAngles += speed * Time.deltaTime;
    }
}
