using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
  


    private void OnTriggerEnter2D(Collider2D collision)
    {

        float randomX = Random.Range(-5f, 5.5f);
        float positionY = 13f;

        if(collision.tag == "Platform")
        {

            collision.transform.position = new Vector3(randomX, collision.transform.position.y + positionY, collision.transform.position.z);


        }

    }
}
