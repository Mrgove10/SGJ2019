using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject InteractionText;
    public GameObject OtherObject;

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
        if (OtherObject != null)
        {
            if (OtherObject.name == "Door")
            {
                Debug.Log("I am a door");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Computeur")
            {
                Debug.Log("I am a Computeur");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Toilet")
            {
                Debug.Log("I am a Toilet");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Balance")
            {
                Debug.Log("I am a Balance");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Pharmacie")
            {
                Debug.Log("I am a Pharmacie");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Fridge")
            {
                Debug.Log("I am a Fridge");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OtherObject = other.gameObject;
        if (other.tag == "Interactable")
        {
            InteractionText.SetActive(true);
            Debug.Log("you can interact whit me");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interactable")
        {
            Debug.Log("you can interact whit me");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OtherObject = null;
        InteractionText.SetActive(false);
    }
}