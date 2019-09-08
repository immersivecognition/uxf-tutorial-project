using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public Material[] options;
    public MeshRenderer meshRenderer;

    void OnValidate()
    {
        Material selectedMaterial = options[Random.Range(0, options.Length)];
        meshRenderer.material = selectedMaterial;
    }
}
