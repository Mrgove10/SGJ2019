using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("nms");
        MyNotifications.CallNotification("ldsdsdol", 3);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       
    }
}