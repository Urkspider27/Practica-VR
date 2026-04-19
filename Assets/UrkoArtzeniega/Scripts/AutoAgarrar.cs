using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class AutoAgarrar : MonoBehaviour
{
    public GameObject mando;
    public GameObject espada;

    void Start()
    {
        var interactor = mando.GetComponent<XRDirectInteractor>();
        var interactable = espada.GetComponent<XRGrabInteractable>();

        if (interactor != null && interactable != null)
        {
            // Forzamos el agarre manual
            interactor.StartManualInteraction((IXRSelectInteractable)interactable);
        }
        else
        {
            Debug.LogError("Oye, te falta el componente XRDirectInteractor en el mando o el XRGrabInteractable en la espada!");
        }
    }
}