using Assets.Scripts;
using Assets.Scripts.MainGame.Class;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public Toggle ToggleM;
    public Toggle ToggleF;
    public InputField InputNom;
    private string FileContent;
    public TextAsset Json;

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
        SceneManager.LoadSceneAsync("LoadingInfo");
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
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, "Story.json");

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            FileContent = File.ReadAllText(filePath);
            FileContent = FileContent.Replace("{pseudo}", PlayerName);
            Variables.MissionList = JsonConvert.DeserializeObject<List<Mission>>(FileContent);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}