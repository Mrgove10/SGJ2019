using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Collider PlayerCollider;

    public bool enter = true;
    public bool exit = true;

    // Start is called before the first frame update
    private void Start()
    {/*
        if (PlayerCollider == null)
        {
            PlayerCollider = this.GetComponent<Collider>();
        }*/
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter == true)
        {
            Debug.Log("entered");
            Debug.Log(other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit == true)
        {
            Debug.Log("exit");
        }
    }
}