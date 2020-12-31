using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformObject;
    public int platformNumber;
    public float minX, maxX, minY, maxY;


    void Start()
    {

        Vector3 clonePosition = new Vector3();

        for(int i = 0; i < platformNumber; i++)
        {

            clonePosition.x = Random.Range(minX, maxX);
            clonePosition.y = Random.Range(minY, maxY);

            Instantiate(platformObject, clonePosition, Quaternion.identity); //obje oluşturmak ve klonlamak için (klonlanacak obje , pozisyon , açı)  Quaternion kullandık neden 
                                                                            //transform position değil çünkü üzerinde çalışan objenin açısı alıyormuş.  //Bununla tümüne 0 dedik.
            
        /*  **************************************************  Obje üzerinden kaldırdım unity de unutma ************************************************** */
        }


    }

}
