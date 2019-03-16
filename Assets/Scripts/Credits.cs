﻿using Assets.Scripts;
using Assets.Scripts.MainGame.Class;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Button Credit;

    // Start is called before the first frame update
    void Start()
    {
        if (Credit == null)
        {
            Credit = GameObject.Find("ButtonCredits").GetComponent<Button>();
            Credit.onClick.AddListener(OnCreditButtonClicked);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCreditButtonClicked()
    {
        Debug.Log("Credits Button clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
