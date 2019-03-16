using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Collider PlayerCollider;

    public GameObject InteractionText;

    // Start is called before the first frame update
    private void Start()
    {
        if (InteractionText == null)
        {
            InteractionText = GameObject.Find("TextInteract");
            InteractionText.SetActive(false);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.tag == "Interactable")
        {
            Debug.Log("you can interact whit me");
            InteractionText.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("entered");
        if (other.tag == "Interactable")
        {
            Debug.Log("you can interact whit me");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        InteractionText.SetActive(false);
    }
}