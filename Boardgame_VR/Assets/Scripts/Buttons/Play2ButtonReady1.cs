using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1ButtonReady2 : MonoBehaviour
{
    public Material[] material;
    public teli p2;
    Renderer button1;

    void Start()
    {
        button1 = GetComponent<Renderer>();
        button1.sharedMaterial = material[0];

    }


    void Update()
    {
        if (teli.p2 == true)
        {
            button1.sharedMaterial = material[1];
        }
    }
}
