using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EchapMenu : MonoBehaviour
{
    public bool IsEscapeMenuPossible = true;

    public bool MenuActive = false;

    public GameObject EscapeMenu;

    public Button QuitButtonESC;

    // Start is called before the first frame update
    private void Start()
    {
        EscapeMenu = GameObject.Find("EscapeMenu");
        EscapeMenu.SetActive(false);
        if (QuitButtonESC == null)
        {
            QuitButtonESC = GameObject.Find("QuitButtonESC").GetComponent<Button>();
            QuitButtonESC.onClick.AddListener(OnQuitButtonESCClicked);
        }
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

    void OnQuitButtonESCClicked()
    {
        Application.Quit();
    }
}