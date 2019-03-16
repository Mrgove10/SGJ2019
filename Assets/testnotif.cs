using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testnotif : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyNotifications.CallNotification("test" , 3);
        CreateNoti("Medecin", "cc t gro frr", 3);
    }

    public void CreateNoti(string titre, string desc, float duree)
    {
        MyNotifications.CallNotification(titre, duree);
        MyNotifications.CallNotification(desc, duree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
