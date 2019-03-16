using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauge : MonoBehaviour
{

    public Slider jaugeSante;
    public Slider jaugeViePriv;
    [Range(0, 100)]
    public int Sante = 50;
    [Range(0, 100)]
    public int ViePriv = 100;


    // Start is called before the first frame update
    void Start()
    {
      

        if (jaugeSante == null)
        {
            jaugeSante = GameObject.Find("SliderSante").GetComponent<Slider>();
            jaugeSante.value = Sante;
        }

        if (jaugeViePriv == null)
        {
            jaugeViePriv = GameObject.Find("SliderViePriv").GetComponent<Slider>();
            jaugeViePriv.value = ViePriv;
        }
    }

    // Update is called once per frame
    void Update()
    {
        jaugeSante.value = Sante;
        jaugeViePriv.value = ViePriv;

    }
}
