using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public float speed;

    public Image ImageToFade;
    // Start is called before the first frame update
    void Start()
    {
     //   ImageToFade.a
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void StartFade()
    {
        StartCoroutine("FadeImage");
    }

   /* IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
      
    }*/

}
