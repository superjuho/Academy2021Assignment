using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform)
        {
            if(playerTransform.position.y > transform.position.y)
                    {
                        transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
                    }
        }
        
        
    }
}
