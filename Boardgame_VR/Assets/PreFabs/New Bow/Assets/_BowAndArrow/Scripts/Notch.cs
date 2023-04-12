using UnityEngine; // Import the Unity Engine library
using UnityEngine.XR.Interaction.Toolkit; // Import the XR Interaction Toolkit library

public class Notch : XRSocketInteractor // Declare the Notch class as a child of the XRSocketInteractor class
{
    [SerializeField, Range(0, 1)] private float releaseThreshold = 0.25f; // Declare a private float variable called "releaseThreshold" that can be set in the Inspector window and initialized with a range of 0 to 1

    public Bow Bow { get; private set; } // Declare a public property called "Bow" that gets the Bow object that the Notch is a child of
    public PullMeasurer PullMeasurer { get; private set; } // Declare a public property called "PullMeasurer" that gets the PullMeasurer component that the Notch is a child of

    public bool CanRelease => PullMeasurer.PullAmount > releaseThreshold; // Declare a public boolean property called "CanRelease" that returns true if the PullAmount of the PullMeasurer is greater than the releaseThreshold, and false otherwise

    protected override void Awake() // Override the Awake method
    {
        base.Awake(); // Call the base Awake method
        Bow = GetComponentInParent<Bow>(); // Get the Bow object that the Notch is a child of
        PullMeasurer = GetComponentInChildren<PullMeasurer>(); // Get the PullMeasurer component that the Notch is a child of
    }

    protected override void OnEnable() // Override the OnEnable method
    {
        base.OnEnable(); // Call the base OnEnable method
        PullMeasurer.selectExited.AddListener(ReleaseArrow); // Add the ReleaseArrow method as a listener for the selectExited event of the PullMeasurer
    }

    protected override void OnDisable() // Override the OnDisable method
    {
        base.OnDisable(); // Call the base OnDisable method
        PullMeasurer.selectExited.RemoveListener(ReleaseArrow); // Remove the ReleaseArrow method as a listener for the selectExited event of the PullMeasurer
    }

    public void ReleaseArrow(SelectExitEventArgs args) // Declare a public method called "ReleaseArrow" that takes a SelectExitEventArgs object as a parameter
    {
        if (hasSelection) // Check if the Notch has a selection
            interactionManager.SelectExit(this, firstInteractableSelected); // Call the SelectExit method of the interactionManager with this Notch and the firstInteractableSelected as parameters
    }

    public override void ProcessInteractor(XRInteractionUpdateOrder.UpdatePhase updatePhase) // Override the ProcessInteractor method
    {
        base.ProcessInteractor(updatePhase); // Call the base ProcessInteractor method with the updatePhase as a parameter

        if (Bow.isSelected) // Check if the Bow is selected
            UpdateAttach(); // Call the UpdateAttach method
    }

    public void UpdateAttach() // Declare a public method called "UpdateAttach"
    {
        // Move attach when bow is pulled, this updates the renderer as well
        attachTransform.position = PullMeasurer.PullPosition; // Set the position of the attachTransform to the PullPosition of the PullMeasurer
    }

    public override bool CanSelect(IXRSelectInteractable interactable) // Override the CanSelect method
    {
        // We check for the hover here too, since it factors in the recycle time of the socket
        // We also check that notch is ready, which is set once the bow is picked up
        return QuickSelect(interactable) && CanHover(interactable) && interactable is Arrow && Bow.isSelected; // Return true if Quick
    }

    private bool QuickSelect(IXRSelectInteractable interactable)
    {
        // This method determines whether the Notch can quickly select an interactable object, 
        // which in this case is an Arrow. If the Notch doesn't have a selection yet or if it is
        // already selecting the same interactable object, it will return true, indicating that
        // the selection is allowed. Otherwise, it will return false.
        return !hasSelection || IsSelecting(interactable);
    }

    private bool CanHover(IXRSelectInteractable interactable)
    {
        // This method checks if the Notch can hover over an interactable object. It takes 
        // an IXRSelectInteractable as input and checks if it implements the IXRHoverInteractable
        // interface. If it does, it calls CanHover(hoverInteractable) and returns the result. 
        // Otherwise, it returns false.
        if (interactable is IXRHoverInteractable hoverInteractable)
            return CanHover(hoverInteractable);
        return false;
    }

}
