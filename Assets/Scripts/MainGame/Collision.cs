using UnityEngine;

public class Collision
{
    public GameObject Object;

    public void UserCanInteract()
    {
        Debug.Log("Object is Green");
    }

    public void CanActivate()
    {
        Debug.Log("user can activate");
    }

    public void LeftTrigger()
    {
        Debug.Log("User left teh trigger");
    }
}