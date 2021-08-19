using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBehaviour : MonoBehaviour
{
    float max = 0.21f;
    float min = 0.1f;
    private Vector2 scale;

   

    void Update()
    {
            ScaleCoroutine();
    }

    IEnumerator ScaleCoroutine()
    {
        while(transform.localScale.y > min)
        {
            scale = new Vector2(transform.localScale.y - 0.1f, transform.localScale.x - 0.1f);
        
            yield return new WaitForSeconds(1);
        
            transform.localScale = scale;
        }
        
    }
}
