using UnityEngine;
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

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnNextButtonClicked()
    {
        Debug.Log("Next Button clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Appartement");
    }
}