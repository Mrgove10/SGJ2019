using UnityEngine;
using Assets.Scripts;

public enum Condition { MinimalPrivateLife, MinimalLife, MaximalLife}

[System.Serializable]
public class Notification
{
    public string author;
    public string text;
    public float duration = 3f;

    public int conditionValue;
    public Condition condition;
    public bool Executed = false;
}

public class Notifications : MonoBehaviour
{
    public Notification[] notifications;

    // Start is called before the first frame update
    private void Start()
    {
        //MyNotifications.CallNotification("test", 3);
        ////ATTENTION :
        ////VEILLEZ A BIEN VOULOIR FAIRE LES PHRASES LES PLUS COURTES POSSIBLE POUR EVITER UN DEBORDEMENT
        //CreateNoti("Patron2merde", "Salut ! Je veux juste te dire que ta maladie c'est de la merde !", 5);
        //MyNotifications.CallNotification("test2", 3);
    }

    public void CreateNoti(string titre, string desc, float duree)
    {
        MyNotifications.CallNotification(titre + "\n" + desc, duree);
    }

    // Update is called once per frame
    private void Update()
    {
        foreach(Notification notif in notifications)
        {
            if(!notif.Executed)
            {
                // selon condition tester si a afficher
                switch (notif.condition)
                {
                    case Condition.MaximalLife:
                        if (Variables.JaugeSante > notif.conditionValue)
                        {
                            CreateNoti(notif.author, notif.text, notif.duration);
                            notif.Executed = true;
                        }
                        break;
                    case Condition.MinimalLife:
                        if (Variables.JaugeSante < notif.conditionValue)
                        {
                            CreateNoti(notif.author, notif.text, notif.duration);
                            notif.Executed = true;
                        }
                        break;
                    case Condition.MinimalPrivateLife:
                        if (Variables.JaugeViePriv < notif.conditionValue)
                        {
                            CreateNoti(notif.author, notif.text, notif.duration);
                            notif.Executed = true;
                        }
                        break;
                }
            }
            

        }
    }
}