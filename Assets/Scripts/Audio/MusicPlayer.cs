using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject manager;
    public MusicType musicType;
    public AudioSource audioSource;
    private bool isMuted = false;
    private MusicSetup _currentMusicSetup;

    private void Start()
    {
        Play();
    }
    private void Play()
    {
        _currentMusicSetup = SoundManager.Instance.GetMusicByType(musicType);

        audioSource.clip = _currentMusicSetup.audioClip;
        audioSource.Play();
    }
}
