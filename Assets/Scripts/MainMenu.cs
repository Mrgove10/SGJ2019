using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public Toggle ToggleM;
    public Toggle ToggleF;
    public InputField InputNom;
    public bool isPlayPossible;


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
           // PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        if (ToggleM == null)
        {
            ToggleM = GameObject.Find("ToggleM").GetComponent<Toggle>();
            //PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        if (ToggleF == null)
        {
            ToggleF = GameObject.Find("ToggleF").GetComponent<Toggle>();
            //PlayButton.onClick.AddListener(OnPlayButtonClicked);
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
            Debug.Log("TOUT VAS BIEN OUI AAAAAAAA OUI JE PEUX CLIQUER SUR LE BOUTON ASKIP");
            PlayButton.interactable = true;
        }
        else { PlayButton.interactable = false; }
    }

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play Button clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Appartement");
    }

    private void OnQuitButtonClicked()
    {
        Debug.Log("Quit Button clicked");
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }
}