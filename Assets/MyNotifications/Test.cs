using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine("moja");
    }

    private IEnumerator moja()
    {
        yield return new WaitForSeconds(1);

        MyNotifications.CallNotification("Hello World!", 3);
        MyNotifications.CallNotification("MyNotifications", 4);
        MyNotifications.CallNotification("Goodbye World!", 3);
    }
}