using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts;

public class EndGameScript : MonoBehaviour
{
    public Text Texte;
    public Button BoutonRetourMenu;
    private string MessageSante = "Attention, problème au niveau du code. (Santé)";
    private string MessagePrive = "Attention, problème au niveau du code. (Privé)";


    // Start is called before the first frame update
    void Start()
    {
        /* POUR LE DEBUG UNIQUEMENT
        Variables.JaugeSante = 60;
        Variables.JaugeViePriv = 40;*/

        if (Texte == null)
        {
            Texte = GameObject.Find("TexteFin").GetComponent<Text>();
            Texte.text = "ERREUR";
        }

        if (BoutonRetourMenu == null)
        {
            BoutonRetourMenu = GameObject.Find("BackToMenuButton").GetComponent<Button>();
            BoutonRetourMenu.onClick.AddListener(OnMenuButtonClicked);
        }

        if(Variables.JaugeSante >= 90)
        {
            MessageSante = "Bravo ! vous êtes en exellente santé !";
        }
        else if(Variables.JaugeSante < 90 && Variables.JaugeSante >= 80)
        {
            MessageSante = "Vous êtes en très bonne santé !";
        }
        else if(Variables.JaugeSante < 80 && Variables.JaugeSante >= 50)
        {
            MessageSante = "Vous êtes en bonne santé.";
        }
        else if(Variables.JaugeSante < 50 && Variables.JaugeSante >= 25)
        {
            MessageSante = "Vous n'êtes pas vraiment en bonne santé...";
        }
        else if (Variables.JaugeSante < 25)
        {
            MessageSante = "Vous êtes en mauvaise santé.";
        }


        if (Variables.JaugeViePriv >= 90)
        {
            MessagePrive = "Vos données sont à l'abri !";
        }
        else if (Variables.JaugeViePriv < 90 && Variables.JaugeViePriv >= 80)
        {
            MessagePrive = "Vous êtes légèrement exposé sur le net, faites attention.";
        }
        else if (Variables.JaugeViePriv < 80 && Variables.JaugeViePriv >= 50)
        {
            MessagePrive = "Vous êtes exposé sur Internet.";
        }
        else if (Variables.JaugeViePriv < 50 && Variables.JaugeViePriv >= 25)
        {
            MessagePrive = "Même votre employeur sait ce que vous avez mangé ce midi...";
        }
        else if (Variables.JaugeSante < 25)
        {
            MessagePrive = "Toute votre vie est consultable comme un livre ouvert.";
        }

        Debug.Log(MessageSante);
        Debug.Log(MessagePrive);

        Texte.text = MessageSante + "mais, \n" + MessagePrive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMenuButtonClicked()
    {   
        Debug.Log("Retour au menu");
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
