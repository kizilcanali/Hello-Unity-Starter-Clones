using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPosition : MonoBehaviour
{

    public MeshRenderer S1, S2;

    void Update()
    {
        if(S1.material.name == S2.material.name)
        {
            Debug.Log("Winneer!!!1!111!");
        }
    }
}
