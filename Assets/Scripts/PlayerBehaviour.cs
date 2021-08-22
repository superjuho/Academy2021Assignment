using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    public float jumpForce = 9f;
    AudioSource audioSource;
    public AudioClip blip;
    public AudioClip bling;
    public AudioClip stars;

    public Rigidbody2D rigidBody;
    public GameObject PointsUI;
    public GameObject defeat;
    public GameObject collectStar;

    public Color orange;
    public Color cyan;
    public Color pink;
    public Color green;

    public GameObject player;
    public Color playerColor;

    int points = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // get colors of the obstacle objects
        orange = GameObject.Find("Orange").GetComponent<SpriteRenderer>().color;
        cyan = GameObject.Find("Cyan").GetComponent<SpriteRenderer>().color;
        pink = GameObject.Find("Pink").GetComponent<SpriteRenderer>().color;
        green = GameObject.Find("Green").GetComponent<SpriteRenderer>().color;

        // get color component of the player
        playerColor = player.GetComponent<SpriteRenderer>().color; 

        //On game start setting the first random color of the player
        SetRandomColor(4);

    }

    void Update()
    {
        //setting the players color with current color
        player.GetComponent<SpriteRenderer>().color = playerColor;
        //setting the text object in UI to points
        PointsUI.GetComponent<TextMeshProUGUI>().text = points.ToString();

        // jumping action
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            audioSource.PlayOneShot(blip, 1f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
     
        // checking if the player is different color than the object so the player gets destroyed and the game is over
        if (playerColor != collider.GetComponent<SpriteRenderer>().color && collider.CompareTag("Arc"))
        {
            Debug.Log("playerColor: " + playerColor + "collider Color" + collider.GetComponent<SpriteRenderer>().color);
            Destroy(player);
            Instantiate(defeat, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
            
        }

        // checking if the player hits a colorswitcher and the color is changed
        if(collider.CompareTag("ColorSwitcher"))
        {
            audioSource.PlayOneShot(bling, 1f);
            SetRandomColor(4);
            Destroy(collider.gameObject);
            
        }

        // if there is a three colored obstacle like triangle, there can be only three colors to change into
        if(collider.CompareTag("ColorSwitcherTre"))
        {
            audioSource.PlayOneShot(bling, 1f);
            SetRandomColor(3);
            Destroy(collider.gameObject);
        }

        // if player collects a star, the prefab is instantiated and the star is destroyed, points go up one point.
        if(collider.CompareTag("Point"))
        {
            points++;
            Destroy(collider.gameObject);
            audioSource.PlayOneShot(stars, 1f);
            float x = collider.gameObject.transform.position.x;
            float y = collider.gameObject.transform.position.y;
            Instantiate(collectStar, new Vector2(x, y), Quaternion.identity);
        }
    }

    // Setting the random color and each case is checking whether the ball is already that color, if it is then the random color is picked again.
    void SetRandomColor(int x)
    {
        int index = Random.Range(0, x);

        switch (index)
        {
            case 0: //orange
                if(playerColor != orange)
                {
                    playerColor = orange;
                }
                else if(playerColor == orange) {
                    SetRandomColor(x);
                }
                break;
            case 1: // cyan
                if (playerColor != cyan)
                {
                    playerColor = cyan;
                }
                else if (playerColor == cyan)
                {
                    SetRandomColor(x);
                }
                break;
            case 2: // pink
                if (playerColor != pink)
                {
                    playerColor = pink;
                }
                else if (playerColor == pink)
                {
                    SetRandomColor(x);
                }
                break;
            case 3: // green
                if (playerColor != green)
                {
                    playerColor = green;
                }
                else if (playerColor == green)
                {
                    SetRandomColor(x);
                }
                break;
        }
    }
}
