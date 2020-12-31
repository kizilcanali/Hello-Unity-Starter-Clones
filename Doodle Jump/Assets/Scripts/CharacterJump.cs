using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{

    public float jumpForce;
    private Vector2 characterSpeed;
    private Rigidbody2D physics;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.y <= 0) {  //bağıl hız sıfıdan küçükse koşuluna bağlı  hızı sıfıra düşmeden aşağıdaki koşulu çalıştırma demek aslında.

        physics = collision.collider.GetComponent<Rigidbody2D>();

        if(physics != null) // fizik null ken çalışamaz
        {
            characterSpeed = physics.velocity;
            characterSpeed.y = jumpForce;
            physics.velocity = characterSpeed;
        }
        }


    }
    }

