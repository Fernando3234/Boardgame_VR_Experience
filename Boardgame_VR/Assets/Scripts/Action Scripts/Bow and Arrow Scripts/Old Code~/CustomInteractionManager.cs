using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractionManager : XRInteractionManager
{
    public void ForceDeselect(XRBaseInteractor interactor)
    {
        if (interactor.interactablesSelected != null && interactor.interactablesSelected.Count > 0)
        {
            XRBaseInteractable interactable = interactor.interactablesSelected[0] as XRBaseInteractable;
            SelectExit(interactor, interactable);
        }
    }

}