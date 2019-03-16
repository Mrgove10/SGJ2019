using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EchapMenu : MonoBehaviour
{
    public bool IsEscapeMenuPossible = true;
    public bool MenuActive = false;
    public GameObject EscapeMenu;
    public Button QuitButtonESC;
    public Button RetunMenuButtonESC;

    // Start is called before the first frame update
    private void Start()
    {
        EscapeMenu = GameObject.Find("EscapeMenu");
        if (QuitButtonESC == null)
        {
            QuitButtonESC = GameObject.Find("QuitButtonESC").GetComponent<Button>();
            QuitButtonESC.onClick.AddListener(OnQuitButtonESCClicked);
        }
        if (RetunMenuButtonESC == null)
        {
            RetunMenuButtonESC = GameObject.Find("RetunMenuButtonESC").GetComponent<Button>();
            RetunMenuButtonESC.onClick.AddListener(OnRetunMenuButtonESCClicked);
        }
        EscapeMenu.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Escape Key Pressed");
            if (MenuActive == true)
            {
                EscapeMenu.SetActive(false);
                MenuActive = false;
            }
            else
            {
                if (IsEscapeMenuPossible == true)
                {
                    MenuActive = true;
                    EscapeMenu.SetActive(true);
                }
            }
        }
    }

    private void OnQuitButtonESCClicked()
    {
        Debug.Log("Quit Button clicked");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit ();
#endif
    }

    private void OnRetunMenuButtonESCClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}