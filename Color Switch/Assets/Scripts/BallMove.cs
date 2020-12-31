using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BallMove : MonoBehaviour
{
     
    public Rigidbody2D ball;   //Topun fiziği için
    public float jumpForce;
    public Color mor, sari, pembe, turkuaz;
    public string currentColor;
    public SpriteRenderer ballSprite;  //Topun rengi için kullandık.
    public Transform colorChanger; //renk değiştiriciyi tutmak için.
    int score;
    public TextMeshProUGUI scoreText;

    public Transform control1, circle1, control2, circle2;   //Sonsuz oyun için
    public AudioSource jump;


    private void Start()
    {
        randomColor();
    }
    
    void Update()
        {
       
        if (Input.GetKeyDown(KeyCode.UpArrow)) { 
        ball.velocity = Vector2.up * jumpForce; // UpArraw a basıldıgında topu jumpForce ile çarparak yukarıya fırlatır.
            jump.Play();
        }
        scoreText.text = score.ToString();
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.tag != currentColor && collision.tag != "ColorChanger" && collision.tag != "Controller1" && collision.tag != "Controller2")  //Sahne renk değiştiriciye çarpınca tekrar başlamasın diye 2. koşul eklendi.
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Aktif sahneyi tekrar başlat.
        }
        
        if(collision.tag == "ColorChanger")
        {
            colorChanger.position = new Vector3(colorChanger.position.x, colorChanger.position.y + 3.5f, 0f);  //Her oje 3.5 üzerinde yer alıyor bir öncekinin. Ona uygun olarak renk değiştiriciyi yukarıya gönderdik.
            randomColor();
            score++;
            //Destroy(collision.gameObject);   //Temastan sonra renk değiştiriciyi yok et. (Bunu daha önce kullandık)
        }

        if(collision.tag == "Controller1")
        {
            control1.position = new Vector3(control1.position.x, control1.position.y +7f , control1.position.z);
            circle1.position = new Vector3(circle1.position.x, circle1.position.y + 7f , circle1.position.z);
        }

        if (collision.tag == "Controller2")
        {
            control2.position = new Vector3(control2.position.x, control2.position.y + 7f, control2.position.z);
            circle2.position = new Vector3(circle2.position.x, circle2.position.y + 7f, circle2.position.z);
        }

    }

    void randomColor()    //Topa random renk ataması yapar.
    {
        int colorSelector = Random.Range(1, 5); 

        switch (colorSelector)
        {
            case 1:
                currentColor = "Mor";
                ballSprite.color = mor;
                break;
            case 2:
                currentColor = "Sarı";
                ballSprite.color = sari;
                break;
            case 3:
                currentColor = "Pembe";
                ballSprite.color = pembe;
                break;
            case 4:
                currentColor = "Turkuaz";
                ballSprite.color = turkuaz;
                break;
        }
    }
}
