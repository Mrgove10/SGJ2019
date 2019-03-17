using Assets.Scripts;
using Assets.Scripts.MainGame.Class;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject InteractionText;
    public GameObject OtherObject;

    public GameObject ChoiceWindow;
    public Button YesButton;
    public Button NoButton;
    public Text ChoiceTitle;
    public Text ChoiceParagraph;

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
        MissionNameText.text = Variables.MissionList.Find(mission => mission.Id == Variables.CurrentMissionID).Title;
        MissionNameText.text = Variables.MissionList.Find(mission => mission.Id == Variables.CurrentMissionID).Title;
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
        AfterConfirmation();
    }

    private void NoButtonClicked()
    {
        Choix m = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ChoixNon;
        Variables.JaugeSante = Variables.JaugeSante + m.deltaSanté;
        Variables.JaugeViePriv = Variables.JaugeViePriv + m.deltaViePriv;
        AfterConfirmation();
    }

    private void AfterConfirmation()
    {
        Variables.CurrentMissionID++;
        ChoiceWindow.SetActive(false);

        //TODO :  fondu au noir ici
    }

    private void Showpopup()
    {
        ChoiceTitle.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Title;
        ChoiceParagraph.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Text;
        ChoiceWindow.SetActive(true);
    }

    //private void LoadGameStory(string PlayerName)
    //{
    //    // Path.Combine combines strings into a file path
    //    // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
    //    string filePath = Path.Combine(Application.streamingAssetsPath, "Story.json");

    //    if (File.Exists(filePath))
    //    {
    //        // Read the json from the file into a string
    //        FileContent = File.ReadAllText(filePath);
    //        FileContent = FileContent.Replace("{pseudo}", PlayerName);
    //        Variables.MissionList = JsonConvert.DeserializeObject<List<Mission>>(FileContent);
    //    }
    //    else
    //    {
    //        Debug.LogError("Cannot load game data!");
    //    }
    //}
}