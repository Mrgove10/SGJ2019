using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;

    private void Start()
    {
        if (PlayButton == null)
        {
            PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
            PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }
        if (QuitButton == null)
        {
            QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();
            QuitButton.onClick.AddListener(OnQuitButtonClicked);
        }
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