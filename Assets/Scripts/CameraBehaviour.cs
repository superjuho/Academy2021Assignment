using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public Transform playerTransform;
    public GameObject player;
    public GameObject defeat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform)
        {
           
            if(playerTransform.position.y > transform.position.y) // camera follows the player if player is going upwards
                    {
                        transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
                    }
            if(playerTransform.position.y < (transform.position.y -5)) // if player goes down outside camera it's game over
            {
                Destroy(player);
                Instantiate(defeat, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
            }
        }
        
        
    }
}
