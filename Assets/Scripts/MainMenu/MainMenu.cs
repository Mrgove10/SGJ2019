using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public Button CreditButton;
    public Toggle ToggleM;
    public Toggle ToggleF;
    public InputField InputNom;
    private string FileContent;
    public Scenario scenario;

    private void Start()
    {
        if (PlayButton == null)
        {
            PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
            Variables.MissionList = scenario.missions;
            PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        PlayButton.interactable = false;

        if (CreditButton == null)
        {
            CreditButton = GameObject.Find("CreditButton").GetComponent<Button>();
            CreditButton.onClick.AddListener(OnCreditButtonClicked);
        }

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
        SceneManager.LoadSceneAsync("LoadingInfo");
    }

    private void OnCreditButtonClicked()
    {
        Debug.Log("credti clecked");
        SceneManager.LoadSceneAsync("Credits");
    }

    private void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit ();
#endif
    }
}