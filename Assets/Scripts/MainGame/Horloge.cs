using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Horloge : MonoBehaviour
{
    public int heure = 0;
    public int minute = 0;
    public string horlogue = "";
    public Text horloguetext;

    // Start is called before the first frame update
    private void Start()
    {
       
        StartCoroutine(ajout());
        if (horloguetext == null)
        {
            horloguetext = GameObject.Find("Horloge").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        string minutetxt;
        if (minute <= 9)
        {
            minutetxt = "0" + minute;
        }
        else
        {
            minutetxt = minute.ToString();
        }
        horlogue = heure + ":" + minutetxt;
        horloguetext.text = horlogue;
        Variables.CurrentHeure = heure;
        Variables.CurrentMinute = minute;
        Debug.Log("Horloge var time " + Variables.CurrentHeure + ": " + Variables.CurrentMinute);
    }

    private IEnumerator ajout()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            minute++;
        }
    }
}