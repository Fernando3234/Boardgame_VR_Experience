using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1ButtonReady3 : MonoBehaviour
{
    public Material[] material;
    public teli p3;
    Renderer button1;

    void Start()
    {
        button1 = GetComponent<Renderer>();
        button1.sharedMaterial = material[0];

    }


    void Update()
    {
        if (teli.p3 == true)
        {
            button1.sharedMaterial = material[1];
        }
    }
}
