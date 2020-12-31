using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{

    int blockHealth = 2;
    private MeshRenderer ressam;
    public Material BlueBreak;
    public AudioSource temas;
    private void Start()
    {
        ressam = GetComponent<MeshRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            blockHealth--;
            Winner.score += 15;
            temas.Play();
        }

        if(blockHealth == 1)
        {
            ressam.material = BlueBreak;
        }

        if (blockHealth == 0)
        {
            Destroy(this.gameObject);
            Winner.brokenBlockNumber++;
        }
    }

}
