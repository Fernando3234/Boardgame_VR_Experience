using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class hideShowMenu : MonoBehaviour
{
    public teli p1;
    public teli p2;
    public teli p3;
    public teli p4;
    public GameObject SCREEN;
    public GameObject READY;
    public GameObject UNRADY;


    public static bool menu1;


    // Start is called before the first frame update
    void Start()
    {

        menu1 = false;
        SCREEN.SetActive(menu1);

    }

    public void readyOrNot1()
    {
        teli.p1 = !teli.p1;
    }

    // Update is called once per frame
    void Update()
    {
        READY.SetActive(!teli.p1);
        UNRADY.SetActive(teli.p1);
        SCREEN.SetActive(menu1);

        //READY2.SetActive(!teli.p2);
        ///UNRADY2.SetActive(teli.p2);
        //SCREEN2.SetActive(menu2);

        //READY3.SetActive(!teli.p3);
        //UNRADY3.SetActive(teli.p3);
        //SCREEN3.SetActive(menu3);

        //READY4.SetActive(!teli.p4);
        //UNRADY4.SetActive(teli.p4);
        //SCREEN4.SetActive(menu4);

    }
}
