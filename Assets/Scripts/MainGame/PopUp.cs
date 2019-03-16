using Assets.Scripts;
using Assets.Scripts.MainGame.Class;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public Mission Mission;
    private string FileContent;

    // Start is called before the first frame update
    private void Start()
    {
        if (Variables.MissionList == null || Variables.MissionList.Count == 0)
        {
            LoadGameStory(Variables.NomJoueur);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Mission FirstMission = Variables.MissionList.Find(mission => mission.Id == 0);

        Debug.Log(FirstMission.Heure);

        foreach (Mission mission in Variables.MissionList)
        {
            if (Variables.CurrentMissionID == 0 && Variables.CurrentMinute == 0 && Variables.CurrentHeure == 0)
            {
                Variables.CurrentHeure = FirstMission.Heure;
                Variables.CurrentMinute = FirstMission.Minute;
            }
            if (mission.Heure == Variables.CurrentHeure && mission.Minute == Variables.CurrentMinute)
            {
                Variables.CurrentMissionID = mission.Id;
                Mission = mission;
            }
        }
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