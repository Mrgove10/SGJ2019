using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool canInteract = false;

    public virtual void SetInteractable(bool canInteract)
    {
    }

    public virtual void Interact()
    {
    }
}