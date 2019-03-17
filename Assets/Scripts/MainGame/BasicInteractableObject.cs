using UnityEngine;
using System.Collections;

public class BasicInteractableObject : InteractableObject
{
    public MeshRenderer[] meshRenderers;
    public Color canInteractColor = Color.green;
    public float speed = 1f;

    private IEnumerator coroutine;
    

    IEnumerator ColorTransition(Material mat, Color from, Color to)
    {
        float time = 0f;
        while (time<1f)
        {
            time += Time.deltaTime * speed;
            mat.SetColor("_EmissionColor", Color.Lerp(from, to, time));
            yield return null;
        }
    }


    public override void SetInteractable(bool canInteract)
    {
        foreach (var renderer in meshRenderers)
        {
            if (canInteract)
            {
                //renderer.material.SetColor("_EmissionColor", canInteractColor);
                coroutine = ColorTransition(renderer.material, renderer.material.GetColor("_EmissionColor"), canInteractColor);
                StartCoroutine(coroutine);
                foreach (Material mat in renderer.materials)
                {
                    //mat.SetColor("_EmissionColor", canInteractColor);
                    coroutine = ColorTransition(mat, mat.GetColor("_EmissionColor"), canInteractColor);
                    StartCoroutine(coroutine);
                }
            }
            else
            {
                coroutine = ColorTransition(renderer.material, renderer.material.GetColor("_EmissionColor"), Color.black);
                StartCoroutine(coroutine);
                foreach (Material mat in renderer.materials)
                {
                    coroutine = ColorTransition(renderer.material, renderer.material.GetColor("_EmissionColor"), Color.black);
                    StartCoroutine(coroutine);
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