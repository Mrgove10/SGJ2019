using Assets.Scripts;
using Assets.Scripts.MainGame.Class;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Mission Mission;
    private string FileContent;
    public Text MissionNameText;

    

    // Start is called before the first frame update
    private void Start()
    {

        if (Variables.MissionList == null || Variables.MissionList.Count == 0)
        {
            LoadGameStory(Variables.NomJoueur);
        }

        if (MissionNameText == null)
        {
            MissionNameText = GameObject.Find("TextCurrentMission").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Mission FirstMission = Variables.MissionList.Find(mission => mission.Id == 0);

        foreach (Mission mission in Variables.MissionList)
        {
            if (Variables.CurrentMissionID == 0 && Variables.CurrentMinute == 0 && Variables.CurrentHeure == 0)
            {
                Variables.CurrentMissionID = 0;
                Variables.CurrentHeure = FirstMission.Heure;
                Variables.CurrentMinute = FirstMission.Minute;
            }
            if (mission.Heure == Variables.CurrentHeure && mission.Minute == Variables.CurrentMinute)
            {
                Variables.CurrentMissionID = mission.Id;
                Mission = mission;
            }
        }

        MissionNameText.text = Variables.MissionList.Find(mission => mission.Id == Variables.CurrentMissionID).Title;
        Debug.Log(Mission.Id);
    }

    private void LoadGameStory(string PlayerName)
    {
        FileContent = File.ReadAllText("Assets/Scripts/Story.json");
        FileContent = FileContent.Replace("{pseudo}", PlayerName);
        Variables.MissionList = JsonConvert.DeserializeObject<List<Mission>>(FileContent);

        Debug.Log(FileContent);
        foreach (var pp in PlayerName)
        {
            //Debug.Log(pp.Text);
        }
    }
}