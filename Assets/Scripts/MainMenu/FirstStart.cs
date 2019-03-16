using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.MainGame.Class;
using Newtonsoft.Json;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    JsonSerializer Js = new JsonSerializer();
    // Start is called before the first frame update
    private void Start()
    {
        var l = new Choix();
        var m = JsonConvert.SerializeObject(l);
        Debug.Log(m);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}