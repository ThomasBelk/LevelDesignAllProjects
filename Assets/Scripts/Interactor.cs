using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

interface IInteractable
{
    public void Interact();
    public void Drop();
}

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactSource;
    [SerializeField] private float interactRange;
    bool interacting = false;
    bool isHolding = false;
    bool droping = false;
    IInteractable currentObject;

    void Update()
    {
        if (interacting && !isHolding)
        {
            Ray r = new Ray(interactSource.position, interactSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObj))
                {
                    interactableObj.Interact();
                    isHolding = true;
                    currentObject = interactableObj;
                }
            }
        }
        else if (droping && isHolding)
        {
            currentObject.Drop();
            isHolding = false;
            currentObject = null;
        }
    }

    public void RecieveInput(bool inter, bool droper)
    {
        interacting = inter;
        droping = droper;
    }
}
