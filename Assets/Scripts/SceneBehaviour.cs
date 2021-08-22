using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverCanvas;
    


    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if(!player) // if player is destroyed, the gameover canvas is set active
        {
            gameOverCanvas.SetActive(true);
        }

        if(!player && Input.GetMouseButtonDown(0))
        {
            Restart();
        }
    }

    void Restart() // restarting the scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
