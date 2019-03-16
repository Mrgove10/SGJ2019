using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        MyNotifications.CallNotification("test", 3);
        CreateNoti("Patron2merde", "Salut ! Je veux juste te dire que ta maladie c'est de la merde !", 3);
    }

    public void CreateNoti(string titre, string desc, float duree)
    {
        MyNotifications.CallNotification(titre + "\n" + desc, duree);
     
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
       
    }
}