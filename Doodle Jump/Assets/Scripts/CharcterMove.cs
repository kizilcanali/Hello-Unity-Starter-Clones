using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharcterMove : MonoBehaviour
{

    public float speed;
    public Rigidbody2D doodle;
    private float moveInput;
    public TextMeshProUGUI scoreText;
    int score;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal") * speed;   //Sağ-Sol ok veya A-D tuşlarıyla çalışır. Sayı doğrusu üzerinden düşünürsek bana 1 veya -1 verir.
        doodle.velocity = new Vector2(speed * moveInput, doodle.velocity.y);

        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

       if(collision.gameObject.tag == "Platform")
        {
            score += Random.Range(1, 6);
        }
    }
}
