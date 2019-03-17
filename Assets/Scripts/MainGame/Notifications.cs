using UnityEngine;

public class Notifications : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        MyNotifications.CallNotification("test", 3);
        //ATTENTION :
        //VEILLEZ A BIEN VOULOIR FAIRE LES PHRASES LES PLUS COURTES POSSIBLE POUR EVITER UN DEBORDEMENT
        CreateNoti("Patron2merde", "Salut ! Je veux juste te dire que ta maladie c'est de la merde !", 5);
        MyNotifications.CallNotification("test2", 3);
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