using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCard : MonoBehaviour
{
    public teli gameWorld;
    int randNum;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        randNum = Random.Range(1,5);
        Debug.Log(randNum);
        teli.gameWorld = randNum;
    }
}
