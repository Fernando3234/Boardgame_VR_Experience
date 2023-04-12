using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Arrow : XRGrabInteractable
{
    [SerializeField] private float speed = 2000.0f; // the speed at which the arrow will be launched

    private new Rigidbody rigidbody; // rigidbody component attached to the arrow
    private ArrowCaster caster; // the script that casts rays in front of the arrow to check for collision with objects

    private bool launched = false; // flag indicating if the arrow has been launched

    private RaycastHit hit; // variable to store the raycast hit information

    protected override void Awake()
    {
        base.Awake();
        rigidbody = GetComponent<Rigidbody>(); // get the Rigidbody component attached to the arrow
        caster = GetComponent<ArrowCaster>(); // get the ArrowCaster script attached to the arrow
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactorObject is Notch notch)
        {
            if (notch.CanRelease)
                LaunchArrow(notch); // launch the arrow if the notch can be released
        }
    }

    private void LaunchArrow(Notch notch)
    {
        launched = true; // set the launched flag to true
        ApplyForce(notch.PullMeasurer); // apply force to the arrow based on how far the notch was pulled back
        StartCoroutine(LaunchRoutine()); // start the LaunchRoutine coroutine
    }

    private void ApplyForce(PullMeasurer pullMeasurer)
    {
        rigidbody.AddForce(transform.forward * (pullMeasurer.PullAmount * speed)); // apply force to the arrow based on how far the notch was pulled back
    }

    private IEnumerator LaunchRoutine()
    {
        // Set direction while flying
        while (!caster.CheckForCollision(out hit)) // check for collision with objects while the arrow is flying
        {
            SetDirection(); // set the direction of the arrow based on its velocity
            yield return null; // wait for the next frame
        }

        // Once the arrow has stopped flying
        DisablePhysics(); // disable the physics on the arrow
        ChildArrow(hit); // make the arrow a child of the object it hit
        CheckForHittable(hit); // check if the object it hit is hittable
    }

    private void SetDirection()
    {
        if (rigidbody.velocity.z > 0.5f) // if the arrow is moving forward
            transform.forward = rigidbody.velocity; // set the direction of the arrow to be the same as its velocity
    }

    private void DisablePhysics()
    {
        rigidbody.isKinematic = true; // make the arrow kinematic so it can be moved around without physics
        rigidbody.useGravity = false; // disable gravity on the arrow
    }

    private void ChildArrow(RaycastHit hit)
    {
        transform.SetParent(hit.transform); // make the arrow a child of the object it hit
    }

    private void CheckForHittable(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out IArrowHittable hittable)) // if the object it hit has an IArrowHittable component
            hittable.Hit(this); // call the Hit function on the hittable object
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        return base.IsSelectableBy(interactor) && !launched; // the arrow can only be selected if it hasn't been launched yet
    }
}
