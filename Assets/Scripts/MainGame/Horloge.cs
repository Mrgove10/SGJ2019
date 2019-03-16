using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Horloge : MonoBehaviour
{
    public string horlogue = "";
    public Text horloguetext;
    public bool starthorloge = false;

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
        if (Variables.CurrentMinute <= 9)
        {
            minutetxt = "0" + Variables.CurrentMinute;
        }
        else
        {
            minutetxt = Variables.CurrentMinute.ToString();
        }
        horlogue = Variables.CurrentHeure + ":" + minutetxt;
        horloguetext.text = horlogue;
        Debug.Log("Horloge var time " + Variables.CurrentHeure + ": " + Variables.CurrentMinute);
    }

    private IEnumerator ajout()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (Variables.CurrentMinute <= 60)
            {
                Variables.CurrentMinute++;
            }
            else
            {
                Variables.CurrentHeure++;
                Variables.CurrentMinute = 0;
            }
        }
    }
}