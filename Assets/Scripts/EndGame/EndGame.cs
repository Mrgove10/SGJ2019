using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Button BackToMenuButton;

    // Start is called before the first frame update
    private void Start()
    {
        if (BackToMenuButton == null)
        {
            BackToMenuButton = GameObject.Find("BackToMenuButton").GetComponent<Button>();
            BackToMenuButton.onClick.AddListener(BackTomenuButtonClicked);
        }
    }

    // Update is called once per frame
    private void Update()
    {   
    }

    public void BackTomenuButtonClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}