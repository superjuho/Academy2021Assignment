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
    public AudioClip blap;

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
        player = GameObject.Find("PlayerDot");
        orange = GameObject.Find("Orange").GetComponent<SpriteRenderer>().color;
        cyan = GameObject.Find("Cyan").GetComponent<SpriteRenderer>().color;
        pink = GameObject.Find("Pink").GetComponent<SpriteRenderer>().color;
        green = GameObject.Find("Green").GetComponent<SpriteRenderer>().color;

        playerColor = player.GetComponent<SpriteRenderer>().color;

        SetRandomColor(4);

    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<SpriteRenderer>().color = playerColor;
        PointsUI.GetComponent<TextMeshProUGUI>().text = points.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            audioSource.PlayOneShot(blip, 1f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (playerColor != collider.GetComponent<SpriteRenderer>().color && collider.CompareTag("Arc"))
        {
            Debug.Log("playerColor: " + playerColor + "collider Color" + collider.GetComponent<SpriteRenderer>().color);
            Destroy(player);
            Instantiate(defeat, new Vector2(0f, 0f), Quaternion.identity);
            
        }

        if(collider.CompareTag("ColorSwitcher"))
        {
            audioSource.PlayOneShot(bling, 1f);
            SetRandomColor(4);
            Destroy(collider.gameObject);
            
        }

        if(collider.CompareTag("ColorSwitcherTre"))
        {
            audioSource.PlayOneShot(bling, 1f);
            SetRandomColor(3);
            Destroy(collider.gameObject);
        }

        if(collider.CompareTag("Point"))
        {
            points++;
            Destroy(collider.gameObject);
            audioSource.PlayOneShot(blap, 1f);
            float x = collider.gameObject.transform.position.x;
            float y = collider.gameObject.transform.position.y;
            Instantiate(collectStar, new Vector2(x, y), Quaternion.identity);
        }
    }

    void SetRandomColor(int x)
    {
        int index = Random.Range(0, x);

        switch (index)
        {
            case 0:
                playerColor= orange;
                break;
            case 1:
                playerColor = cyan;
                break;
            case 2:
                playerColor = pink;
                break;
            case 3:
                playerColor = green;
                break;
        }
    }
}
