using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Button Next;
    public Text Intro;
    private int Compteur = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Next == null)
        {
            Next = GameObject.Find("ButtonNext").GetComponent<Button>();
            Next.onClick.AddListener(OnNextButtonClicked);
        }

        if (Intro == null)
        {
            Intro = GameObject.Find("TextIntro").GetComponent<Text>();
            Intro.text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque error fugiat minima quasi quas distinctio quod reiciendis id voluptatem accusamus? Quam corrupti deleniti ipsum. Hic beatae minima debitis consequatur tempore.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnNextButtonClicked()
    {
        Debug.Log("Next Button clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Appartement");
    }
}
