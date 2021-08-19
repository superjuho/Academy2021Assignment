using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip defeat;
    public GameObject player;
    bool GameOver = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player && !GameOver)
        {
            audioSource.PlayOneShot(defeat, 1f);
            GameOver = true;
            return;
        }
    }
}
