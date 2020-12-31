using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform ballPosition; //transform yer belirtir


    void Update()
    {

        if(ballPosition.position.y > transform.position.y)  //Top ilerledikce y pozisyonu artacak o zaman takip edecek. 2. kısım direk kameraya vereceğimiz için direk yazdık orayı.
        {

            transform.position = new Vector3(transform.position.x, ballPosition.position.y, transform.position.z);
        }
        
    }
}
