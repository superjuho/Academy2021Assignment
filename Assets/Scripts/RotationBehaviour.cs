using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{

    public float rotationSpeed = 2000f;


    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); 
    }
}