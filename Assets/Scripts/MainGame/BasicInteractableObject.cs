using UnityEngine;

public class BasicInteractableObject : InteractableObject
{
    public MeshRenderer[] meshRenderers;
    public Color canInteractColor = Color.green;

    public override void SetInteractable(bool canInteract)
    {
        foreach (var renderer in meshRenderers)
        {
            if (canInteract)
            {
                renderer.material.SetColor("_EmissionColor", canInteractColor);
                foreach (Material mat in renderer.materials)
                {
                    mat.SetColor("_EmissionColor", canInteractColor);
                }
            }
            else
            {
                renderer.material.SetColor("_EmissionColor", Color.black);
                foreach (Material mat in renderer.materials)
                {
                    mat.SetColor("_EmissionColor", Color.black);
                }
            }
        }
    }

    public override void Interact()
    {
        SetInteractable(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter");
        SetInteractable(true);
    }

    private void OnTriggerExit(Collider other)
    {
        SetInteractable(false);
    }
}