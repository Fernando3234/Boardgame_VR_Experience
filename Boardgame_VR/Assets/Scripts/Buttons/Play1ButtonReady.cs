using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1ButtonReady1 : MonoBehaviour
{
    public Material[] material;
    public teli p1;
    Renderer button1;

    void Start()
    {
        button1 = GetComponent<Renderer>();
        button1.sharedMaterial = material[0];

    }


    void Update()
    {
        if (teli.p1 == true)
        {
            button1.sharedMaterial = material[1];
        }
        else if (teli.p1 == false)
        {
            button1.sharedMaterial = material[0];
        }
    }
}
