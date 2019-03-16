using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.MainGame.Class;
using Newtonsoft.Json;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    private string FileContent;
    // Start is called before the first frame update
    private void Start()
    {
        FileContent = File.ReadAllText("Assets/Scripts/Story.json");
       var p = JsonConvert.DeserializeObject<List<Mission>>(FileContent, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

      Debug.Log(FileContent);
      foreach (var pp in p)
      {
          Debug.Log(pp.Text);
      }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}