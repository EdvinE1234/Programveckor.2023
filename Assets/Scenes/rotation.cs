using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotatespeed;
    public bool autorotate;
    // Update is called once per frame    

    void Update()
    {
        if (autorotate)
        {
            transform.Rotate(0, 0 , rotatespeed * Time.deltaTime);
        }
    }
} 