using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{
    public float offset;
    public float speed;
    public float amplitude;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = offset + (Time.time * speed) % amplitude;
        transform.position = pos;
    }
}
