using Assets.Scripts;
using Assets.Scripts.MainGame.Class;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public Toggle ToggleM;
    public Toggle ToggleF;
    public InputField InputNom;
    private string FileContent;

    private void Start()
    {
        if (PlayButton == null)
        {
            PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
            PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        PlayButton.interactable = false;

        if (InputNom == null)
        {
            InputNom = GameObject.Find("InputNom").GetComponent<InputField>();
        }

        if (ToggleM == null)
        {
            ToggleM = GameObject.Find("ToggleM").GetComponent<Toggle>();
        }

        if (ToggleF == null)
        {
            ToggleF = GameObject.Find("ToggleF").GetComponent<Toggle>();
        }

        if (QuitButton == null)
        {
            QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();
            QuitButton.onClick.AddListener(OnQuitButtonClicked);
        }
    }

    public void FixedUpdate()
    {
        if ((ToggleM.isOn || ToggleF.isOn) && InputNom.text != "")
        {
            PlayButton.interactable = true;
        }
        else { PlayButton.interactable = false; }
    }

    private void OnPlayButtonClicked()
    {
        Variables.NomJoueur = InputNom.text;
        Debug.Log("Nom choisi par le joueur: " + Variables.NomJoueur);
        LoadGameStory(InputNom.text);
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingInfo");
    }

    private void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit ();
#endif
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