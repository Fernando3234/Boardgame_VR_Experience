using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventFinished : MonoBehaviour
{
    public float timeRemaining;

    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
