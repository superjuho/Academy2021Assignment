using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{

    public float rotationSpeed;

    // rotates the gameobject according to the speed set in the editor.
    // attached to the obstacles
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); 
    }
}
