using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squares : MonoBehaviour
{

    MeshRenderer ressam;
    public Material sari, yesil, mavi, mor, kırmızı;
    public AudioSource colorAudio;
    void Start()
    {
        ressam = GetComponent<MeshRenderer>();  //Objenin mesh rendereer componentine ulaşma.(Neye istersen işte.)
        setColor();

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            setColor();
            colorAudio.Play();
        }
        
    }


    void setColor()
    {

        int randomN = Random.Range(1, 6);

        switch (randomN)
        {
            case 1:
                ressam.material = sari;
                break;

            case 2:
                ressam.material = yesil;
                break;

            case 3:
                ressam.material = mavi;
                break;

            case 4:
                ressam.material = mor;
                break;

            case 5:
                ressam.material = kırmızı;
                break;
        }

        

    }
}
