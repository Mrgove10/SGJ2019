using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button QuitButton;
    public Button PlayButton;

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
        Debug.Log("Quit Button clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("appartement");
    }

    private void OnQuitButtonClicked()
    {
        Debug.Log("Quit Button clicked");
        Application.Quit();
    }
}