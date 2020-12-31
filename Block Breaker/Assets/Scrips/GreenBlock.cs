using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : MonoBehaviour
{

    int blockHealth = 1;
    public AudioSource temas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Ball")
        {
            blockHealth--;
            Winner.score += 10; //Winner clasındaki score yi arttırdık.
            temas.Play();
        }

        if(blockHealth == 0)
        {
            Destroy(this.gameObject);
            Winner.brokenBlockNumber++;
        }
    }

}
