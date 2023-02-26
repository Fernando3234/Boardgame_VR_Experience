using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject String;
    private LineRenderer lineRenderer;
    private GameObject Middle;
    public Transform middle;
    private Transform target;
    


    // Start is called before the first frame update
    void Start()
    {
        
        middle = String.transform.Find("Middle");
        lineRenderer = String.GetComponent<LineRenderer>();
        target = middle;
        
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, target.position);

    }



}
