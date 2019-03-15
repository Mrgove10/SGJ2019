using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Horloge : MonoBehaviour
{

    public int heure = 0;

    public int minute = 0;
    public string horlogue = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(ajout());
        horlogue = heure + ":" + minute;
        Debug.Log(horlogue);
    }

    IEnumerator ajout()
    {
        yield return new WaitForSeconds(1);
        minute++;
    }
}
