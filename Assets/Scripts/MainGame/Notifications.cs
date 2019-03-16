using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Notifications : MonoBehaviour
{

    public List<Notif> ListNotif;

    public GameObject NotifUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Notif notif in ListNotif)
        {
            if (notif.heure == Varriables.CurrentHeure && notif.minute == Varriables.CurrentMinute)
            {
                Debug.Log("vouvou");
            }
        }
    }
}
