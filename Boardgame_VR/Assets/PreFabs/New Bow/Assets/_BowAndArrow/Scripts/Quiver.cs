using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Quiver : XRBaseInteractable
{
    [SerializeField] private GameObject arrowPrefab;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // When the Quiver is selected by an interactor, create a new Arrow and immediately select it.
        base.OnSelectEntered(args);
        CreateAndSelectArrow(args);
    }

    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        // Create a new Arrow object and immediately select it, forcing it into the interacting hand.
        Arrow arrow = CreateArrow(args.interactorObject.transform);
        interactionManager.SelectEnter(args.interactorObject, arrow);
    }

    private Arrow CreateArrow(Transform orientation)
    {
        // Create a new Arrow object by instantiating the arrowPrefab and setting its position and rotation
        // to match the orientation of the Quiver's interactor. Return the Arrow component of the new object.
        GameObject arrowObject = Instantiate(arrowPrefab, orientation.position, orientation.rotation);
        return arrowObject.GetComponent<Arrow>();
    }
}
