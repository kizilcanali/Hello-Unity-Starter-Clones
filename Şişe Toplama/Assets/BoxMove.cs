using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public float speed;
    int score = 0;
    public Transform sise;
    public TextMeshProUGUI point;
    public AudioSource collectBottle;

    void Update()
    {
        point.text = "Score: " + score; //UI de score yi yazdıracak.

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        float xPosition = Random.Range(-6f, 6f);
       
        if(collision.gameObject.tag == "Sise")  //Temas ettiğim objenin tag'ı Sise ise....
        {
            sise.position = new Vector3(xPosition, 6f, 0f);     //Objenin pozisyonunu ayarlıyor. Yeni pozisyona gönderiyor.
            score++;
            collectBottle.Play();
        }
        
            }
        }
        
       
   