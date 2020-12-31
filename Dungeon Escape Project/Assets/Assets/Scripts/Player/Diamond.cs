using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public int valueOfDiamond = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            //collect and destroy
            if(player != null)
            {

                player.AddGems(valueOfDiamond);
                
                Destroy(this.gameObject);
            }
        }
    }


}
