using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //private float fade;
    //private bool max;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!max)
        //{
        //    if (fade == 10)
        //    {
        //        max = true;
        //    }
        //    else
        //    {
        //        fade += 1 * Time.deltaTime;
        //    }
        //}
        float rotate = 5f * Time.deltaTime;
        transform.Rotate(0, rotate, 0); //rotates 50 degrees per second around z axis
    }
}
