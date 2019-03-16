using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Button Next;

    // Start is called before the first frame update
    private void Start()
    {
        if (Next == null)
        {
            Next = GameObject.Find("ButtonNext").GetComponent<Button>();
            Next.onClick.AddListener(OnNextButtonClicked);
        }
    }

    private void OnNextButtonClicked()
    {
        Debug.Log("Next Button clicked");
        SceneManager.LoadSceneAsync("Appartement");
    }
}