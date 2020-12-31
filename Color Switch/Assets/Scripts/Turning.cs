using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{


    public float turnSpeed;


    void Update()
    {
        transform.Rotate(0f, 0f, turnSpeed);  // transform.Rotate objeyi döndürür.
    
    }
}
