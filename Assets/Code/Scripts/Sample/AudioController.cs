using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource musicAudioSource;

    private void Awake()
    {
        musicAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        SceneManager.activeSceneChanged += ChangeMusic;
    }

    void ChangeMusic(Scene current, Scene next)
    {
        Debug.Log(1);
        if (next.buildIndex < audioClips.Length && musicAudioSource.clip != audioClips[next.buildIndex])
        {
            musicAudioSource.clip = audioClips[next.buildIndex];
            musicAudioSource.Play();
        }
    }
}
