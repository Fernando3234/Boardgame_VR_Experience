using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class buttonPhysics1 : MonoBehaviour
{
    [SerializeField] private float threshold = 0.5f;
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;


    public UnityEvent onPressed, onReleased;
    public hideShowMenu menu1;

    void Start() {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (isPressed && GetValue() - threshold <= 0 )
        {
            Released();
        }


    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, - 1f, 1f);
    }

    private void Pressed()
    {
        isPressed= true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }
    private void Released()
    {
        isPressed= false;
        onReleased.Invoke();
        Debug.Log("Released");
        hideShowMenu.menu1 = !hideShowMenu.menu1;
    }
}
