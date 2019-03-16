//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public IList<string> Roles { get; set; }
}

public class FirstStart : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        string json = @"{
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ]
}";

      //  Account account = JsonConvert.DeserializeObject<Account>(json);

      //   Debug.Log(account.Email);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}