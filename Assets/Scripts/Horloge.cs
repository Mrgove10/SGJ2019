using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Horloge : MonoBehaviour{
    public int heure = 0;

    public int minute = 0;
    public string horlogue = "";
    public Text horloguetext;

    // Start is called before the first frame update
    private void Start(){
        StartCoroutine(ajout());
    }

    // Update is called once per frame
    private void FixedUpdate(){
        horlogue = heure + ":" + minute;
        horloguetext.text = (heure + " minute");
    }

    private IEnumerator ajout(){
        while (true){
            yield return new WaitForSeconds(1);
            minute++;
            Debug.Log(horlogue);
        }
    }
}