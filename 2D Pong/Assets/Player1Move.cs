using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    public int speed;

    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }
        

    }
}
