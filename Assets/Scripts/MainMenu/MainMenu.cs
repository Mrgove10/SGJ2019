using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public Toggle ToggleM;
    public Toggle ToggleF;
    public InputField InputNom;

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
            Debug.Log("PlayButton is now clickable");
            PlayButton.interactable = true;
        }
        else { PlayButton.interactable = false; }
    }

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play Button clicked");
        Varriables.NomJoueur = InputNom.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingInfo");
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