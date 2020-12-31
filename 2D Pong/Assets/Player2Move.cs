using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public int speed;

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }


    }
}
