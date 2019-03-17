using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Jauge : MonoBehaviour
{
    public Slider jaugeSante;
    public Slider jaugeViePriv;

    [Range(0, 100)]
    public int Sante;

    [Range(0, 200)]
    public int ViePriv;

    // Start is called before the first frame update
    private void Start()
    {
        Sante = Variables.JaugeSante;
        ViePriv = Variables.JaugeViePriv;

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
    private void Update()
    {
        jaugeSante.value = Variables.JaugeSante;
        jaugeViePriv.value = Variables.JaugeViePriv;
    }
}