using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D ball;
    public float xSpeed, ySpeed;
    int p1Score,p2Score;
    public TextMeshProUGUI scoreP1,scoreP2,winner,endOfGame;
    public int maxScore;
    public AudioSource score, win;
    

    void Update()
    {
        scoreP1.text = p1Score.ToString();
        scoreP2.text = p2Score.ToString();

        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      

        if(collision.gameObject.tag == "Player1")
        {
            ball.velocity = new Vector2(-xSpeed, Random.Range(-3f,3f));
        }
        else if(collision.gameObject.tag == "Player2")
        {
            ball.velocity = new Vector2(xSpeed, Random.Range(-3f, 3f));
        }



        if(collision.gameObject.tag == "UpperWall")
        {
            ball.velocity = new Vector2(ball.velocity.x, -ySpeed);
        }
        else if(collision.gameObject.tag == "LowerWall")
        {
            ball.velocity = new Vector2(ball.velocity.x, ySpeed);
        }



        if(collision.gameObject.tag == "RightLine")
        {
            p2Score++;
            transform.position = new Vector2(5.77f, 0f);
            score.Play();
        }
        else if(collision.gameObject.tag == "LeftLine")
        {
            p1Score++;
            transform.position = new Vector2(-5.77f, 0f);
            score.Play();
        }


        if(p1Score == maxScore)
        {
            winner.text = "Winner : Player 1";
            endOfGame.text = "-Enter- to play again!";
            win.Play();
            Time.timeScale = 0;
            
        }
        else if(p2Score == maxScore)
        {
            winner.text = "Winner: Player 2";
            endOfGame.text = "-Enter- to play again!";
            win.Play();
            Time.timeScale = 0;
            
        }

        
    }
}
