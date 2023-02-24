using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teli : MonoBehaviour
{
    public static bool p1;
    public static bool p2;
    public static bool p3;
    public static bool p4;
    public static int gameWorld;

    void Start()
    {
        p1 = false;
        p2 = false;
        p3 = false;
        p4 = false;
        gameWorld= 1;
    }


    public void Update()
    {
        if (p1 == true && p2 == true && p3 == true && p4 == true)
        {
            SceneManager.LoadScene(gameWorld);
        }
    }
}
