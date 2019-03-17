using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject InteractionText;
    public GameObject OtherObject;

    #region choicewindo

    public GameObject ChoiceWindow;
    public Button YesButton;
    public Button NoButton;
    public Text ChoiceTitle;
    public Text ChoiceParagraph;

    #endregion choicewindo

    #region choicewidow2

    public GameObject ChoiceWindowtwo;
    public Button YesButtontwo;
    public Text ChoiceTitletwo;
    public Text ChoiceParagraphtwo;

    #endregion choicewidow2

    public AudioSource Audiosource;

    public Mission Mission;
    private string FileContent;
    public Text MissionNameText;

    // Start is called before the first frame update
    private void Start()
    {
        #region popup

        if (ChoiceTitle == null)
        {
            ChoiceTitle = GameObject.Find("ChoiceTitle").GetComponent<Text>();
        }
        if (ChoiceParagraph == null)
        {
            ChoiceParagraph = GameObject.Find("ChoiceParagraph").GetComponent<Text>();
        }
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

        #endregion popup

        #region popuptwo

        if (ChoiceParagraphtwo == null)
        {
            ChoiceParagraphtwo = GameObject.Find("ChoiceParagraphtwo").GetComponent<Text>();
        }
        if (YesButtontwo == null)
        {
            YesButtontwo = GameObject.Find("okButtontwo").GetComponent<Button>();
            YesButtontwo.onClick.AddListener(YesButtonClicked);
        }

        if (ChoiceWindowtwo == null)
        {
            ChoiceWindowtwo = GameObject.Find("ChoiceWindowtwo");
            ChoiceWindowtwo.SetActive(false);
        }

        #endregion popuptwo

        #region misions

        if (Variables.MissionList == null || Variables.MissionList.Count == 0)
        {
            //LoadGameStory(Variables.NomJoueur);
        }
        if (MissionNameText == null)
        {
            MissionNameText = GameObject.Find("TextCurrentMission").GetComponent<Text>();
        }

        #endregion misions

        #region Audio

        if (Audiosource == null)
        {
            Audiosource = GameObject.Find("Emil").GetComponent<AudioSource>();
        }

        #endregion Audio

        #region interation E

        if (InteractionText == null)
        {
            InteractionText = GameObject.Find("TextInteract");
            InteractionText.SetActive(false);
        }

        #endregion interation E
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (OtherObject != null)
        {
            if (Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ObjetName == OtherObject.name)
            {
                InteractionText.SetActive(true);
                Debug.Log("I am a door");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Showpopup();
                }
            }
        }
        Mission FirstMission = Variables.MissionList.Find(mission => mission.Id == 0);

        foreach (Mission mission in Variables.MissionList)
        {
            if (Variables.CurrentMissionID == 0 && Variables.CurrentMinute == 0 && Variables.CurrentHeure == 0)
            {
                Variables.CurrentMissionID = 0;
                Variables.CurrentHeure = FirstMission.Heure;
                Variables.CurrentMinute = FirstMission.Minute;
            }

            if (mission.Id == Variables.CurrentMissionID)
            {
                Variables.CurrentHeure = mission.Heure;
                Variables.CurrentMinute = mission.Minute;
            }
        }

        MissionNameText.text = Variables.MissionList.Find(mission => mission.Id == Variables.CurrentMissionID).Title;

        if (Mission.Id >= 10)
        {
            BlackScreen bs = new BlackScreen();
            bs.FadeIn();
            SceneManager.LoadSceneAsync("EndGame");
        }

        Debug.Log(Mission.Id);
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
        Choix m = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ChoixOui;
        Variables.JaugeSante = Variables.JaugeSante + m.deltaSanté;
        Variables.JaugeViePriv = Variables.JaugeViePriv + m.deltaViePriv;
        AfterConfirmation(true);
    }

    private void NoButtonClicked()
    {
        Choix m = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ChoixNon;
        Variables.JaugeSante = Variables.JaugeSante + m.deltaSanté;
        Variables.JaugeViePriv = Variables.JaugeViePriv + m.deltaViePriv;
        AfterConfirmation(false);
    }

    private void AfterConfirmation(bool choice)
    {
        Variables.CurrentMissionID++;
        ChoiceWindow.SetActive(false);

        //TODO :  fondu au noir ici  elipse
    }

    private void Showpopup()
    {
        ChoiceTitle.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Title;
        ChoiceParagraph.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Text;

        ChoiceWindow.SetActive(true);
    }

    private ShowpopupSecondaire()
    {
        ChoiceTitle.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Title;
        ChoiceParagraph.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Text;

        ChoiceWindow.SetActive(true);
    }
}