using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    public List<Notif> ListNotif;

    public GameObject NotifUI;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        foreach (Notif notif in ListNotif)
        {
            if (notif.heure == Variables.CurrentHeure && notif.minute == Variables.CurrentMinute)
            {
                Debug.Log("vouvou");
            }
        }
    }
}