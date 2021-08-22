using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverCanvas;
    public GameObject title;
    

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

        if(title.GetComponent<TextMeshProUGUI>().text == "Winner!" && Input.GetMouseButtonDown(0)) // if game was won, restart. 
        {
            Restart();
        }
    }

    void Restart() // restarting the scene
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
