using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] clips;
    public int clipIndex;

    private int audioOffset = 1;

    public GameObject henry;
    public AudioClip ambient;
    
    void Start()
    {
        PlayNextTrack();
    }
    
    void Update()
    {
        if (henry is null || henry.GetComponent<HealthManager>().health < 1)
        {
            clips = new AudioClip[1];
            clips[0] = ambient;
            audioOffset = 4;
            audioPlayer.volume = 1.0f;
        }
    }

    private void PlayNextTrack()
    {
        audioPlayer.Stop();
        if (clipIndex % 2 == 0) //metal soundtrack
        {
            audioPlayer.volume = 0.6f;
        }
        else //ambient
        {
            audioPlayer.volume = 1.0f;
        }
        audioPlayer.clip = clips[clipIndex++ % clips.Length];
        audioPlayer.Play();
        Invoke("PlayNextTrack", audioPlayer.clip.length + audioOffset);
    }
}
