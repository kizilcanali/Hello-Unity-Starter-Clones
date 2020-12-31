using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeminTemas : MonoBehaviour
{
    public Transform sise;
    int health = 3;
    public TextMeshProUGUI healthText,gameOver;
    public AudioSource crashBottle;

    void Update()
    {
        healthText.text = "Health: " + health;

        if (health == 0)
        {
            gameOver.text = "Game Over\nPress any key to play agaın!";
            Time.timeScale = 0;   //oyunu pause

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //sahneyi tekrar başlat
                Time.timeScale = 1; //oyunu başlat
            } 

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        float xPosition = Random.Range(-6f, 6f);
        if (collision.gameObject.tag == "Zemin")
        {
            sise.position = new Vector3(xPosition, 6f, 0f);
            health--;
            crashBottle.Play();
        }
        
    }
}
