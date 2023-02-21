using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1ButtonReady4 : MonoBehaviour
{
    public Material[] material;
    public teli p4;
    Renderer button1;

    void Start()
    {
        button1 = GetComponent<Renderer>();
        button1.sharedMaterial = material[0];

    }


    void Update()
    {
        if (teli.p4 == true)
        {
            button1.sharedMaterial = material[1];
        }
    }
}
