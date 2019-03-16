using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip[] audioClips;
    public float volume = 1f;
}


public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(string name)
    {
        foreach (Sound sound in sounds)
        {
            if(name == sound.name)  
            {
                audioSource.clip = sound.audioClips[Random.Range(0, sound.audioClips.Length)];
                audioSource.volume = sound.volume;
                audioSource.Play();
                break;
            }
        }
    }
}
