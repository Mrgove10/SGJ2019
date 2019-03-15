using System.Collections;
using UnityEngine;

public class Horloge : MonoBehaviour
{
    public int heure = 0;

    public int minute = 0;
    public string horlogue = "";

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ajout());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        horlogue = heure + ":" + minute;
        Debug.Log(horlogue);
    }

    private IEnumerator ajout()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            minute++;
        }
    }
}