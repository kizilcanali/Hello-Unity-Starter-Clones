using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Winner : MonoBehaviour
{

    public TextMeshProUGUI SuccessText;
    public Transform blocks;    // we will use this to count broken blocks we will collect broken blocks here.
    int blockNumber;
    public static int score,brokenBlockNumber;  //Bunun değerini başka scriptten arttıracağız.
    public TextMeshProUGUI scoreText;
    public GameObject writeObj, ballObj, playerObj;
    
    void Start()
    {
        score = 0;
        brokenBlockNumber = 0;
    }

    void Update()
    {
        

        scoreText.text = score.ToString();

        blockNumber = blocks.childCount;  //Unity de blocks altındaki elemananlar child oluyor onların sayısını blockNumber a atamak.
        if(blockNumber == 0)
        {
            SuccessText.text = "Success\n Poınt:" + score + "\n Broken Blocks:" + brokenBlockNumber + "\n\n Press any key to play again";
            Time.timeScale = 0;
            Destroy(writeObj.gameObject);
            Destroy(ballObj.gameObject);
            Destroy(playerObj.gameObject);

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }
}
