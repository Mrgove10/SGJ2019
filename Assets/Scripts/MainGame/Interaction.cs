using Assets.Scripts;
using Assets.Scripts.MainGame.Class;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject InteractionText;
    public GameObject OtherObject;

    public GameObject ChoiceWindow;
    public Button YesButton;
    public Button NoButton;
    public Text ChoiceText;

    // Start is called before the first frame update
    private void Start()
    {
        if (YesButton == null)
        {
            YesButton = GameObject.Find("YesButton").GetComponent<Button>();
            YesButton.onClick.AddListener(YesButtonClicked);
        }
        if (NoButton == null)
        {
            NoButton = GameObject.Find("NoButton").GetComponent<Button>();
            NoButton.onClick.AddListener(NoButtonClicked);
        }
        if (ChoiceWindow == null)
        {
            ChoiceWindow = GameObject.Find("ChoiceWindow");
            ChoiceWindow.SetActive(false);
        }

        if (InteractionText == null)
        {
            InteractionText = GameObject.Find("TextInteract");
            InteractionText.SetActive(false);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (OtherObject != null)
        {
            if (Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ObjetName == OtherObject.name)
            {
                Renderer rend = OtherObject.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.green);
                Debug.Log("I am a door");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Showpopup();
                    InteractionText.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OtherObject = other.gameObject;
        if (other.tag == "Interactable")
        {
            //InteractionText.SetActive(true);
            Debug.Log("you can interact whit me");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interactable")
        {
            Debug.Log("you can interact whit me");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OtherObject = null;
        InteractionText.SetActive(false);
    }

    private void YesButtonClicked()
    {
        ChoiceWindow.SetActive(false);
        Choix m = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ChoixOui;
        Variables.CurrentMissionID++;
        Variables.JaugeSante = Variables.JaugeSante + m.SanteBonus;
        Variables.JaugeSante = Variables.JaugeSante - m.SanteMalus;
        Variables.JaugeViePriv = Variables.JaugeViePriv + m.ViePrivBonus;
        Variables.JaugeViePriv = Variables.JaugeViePriv - m.ViePrivMalus;
    }

    private void NoButtonClicked()
    {
        ChoiceWindow.SetActive(false);
        Choix m = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ChoixNon;
        Variables.CurrentMissionID++;
        Variables.JaugeSante = Variables.JaugeSante + m.SanteBonus;
        Variables.JaugeSante = Variables.JaugeSante - m.SanteMalus;
        Variables.JaugeViePriv = Variables.JaugeViePriv + m.ViePrivBonus;
        Variables.JaugeViePriv = Variables.JaugeViePriv - m.ViePrivMalus;
    }

    private void Showpopup()
    {
        ChoiceWindow.SetActive(true);
        ChoiceText.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Text;
    }
}