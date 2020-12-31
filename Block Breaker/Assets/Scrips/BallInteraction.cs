using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BallInteraction : MonoBehaviour
{
    public Rigidbody2D ball;
    public float horizontalSpeed, verticalSpeed;
    
    public GameObject playerObj, writeText;
    public TextMeshProUGUI looser;


    private void Start()
    {
        ball.velocity = new Vector2(Random.Range(-horizontalSpeed, horizontalSpeed), ball.velocity.y);

    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBlock")
        {
            ball.velocity = new Vector2(ball.velocity.x, verticalSpeed);
        }

        if(collision.gameObject.tag == "RightWall")
        {
            ball.velocity = new Vector2(-horizontalSpeed, ball.velocity.y);
        }

        if(collision.gameObject.tag == "LeftWall")
        {
            ball.velocity = new Vector2(horizontalSpeed, ball.velocity.y);
        }
        if(collision.gameObject.tag == "UpperWall")
        {
            ball.velocity = new Vector2(ball.velocity.x, -verticalSpeed);
        }
       
        if(collision.gameObject.tag == "ExitWall")
        {
            looser.text = "Not bad try agaın\n Poınt: " + Winner.score + "\n Broken Blocks: " + Winner.brokenBlockNumber + "\n\n Press any key to play again";
            Time.timeScale = 0;
            Destroy(playerObj.gameObject);
            Destroy(writeText.gameObject);   //Burada topu silmedik ekrandan kod onun üzerinde çalıştıogı için.
        }

    }

}   
