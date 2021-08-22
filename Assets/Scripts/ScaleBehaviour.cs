using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// I wanted to try to make animation for the start purely with code without using Unitys animation tools. I know it's not the best practice for performance, but wanted to try it.


public class ScaleBehaviour : MonoBehaviour
{
    float max = 0.2f;
    float min = 0.1f;
    private Vector2 scale;
    private bool scaled = false;

    void Start()
    {
        StartCoroutine(ScaleCoroutine());
    }

    void Update()
    {
         if (scaled)
        {
            scaled = false;
            StartCoroutine(ScaleCoroutine());
        }
    }

    IEnumerator ScaleCoroutine()
    {
        while(transform.localScale.y > min)
        {

            scale = new Vector2((transform.localScale.x - 0.01f), (transform.localScale.y - 0.01f));
        
            yield return new WaitForSeconds(0.1f);
        
            transform.localScale = scale;
        }

        while (transform.localScale.y < max)
        {

            scale = new Vector2((transform.localScale.x + 0.01f), (transform.localScale.y + 0.01f));

            yield return new WaitForSeconds(0.1f);

            transform.localScale = scale;
        }

        scaled = true;

    }

  
}
