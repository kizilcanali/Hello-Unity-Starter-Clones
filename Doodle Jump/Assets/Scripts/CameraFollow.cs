using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{



    public Transform target;

  
    void Update()
    {

        if (target.position.y > transform.position.y) //hedef pozisyonu kameradan büyükse 
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);   //direkk transform position yazınca kodun çalıştıgı objeyi alır.
        }

    }
}
