using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public AudioSource button;
    public AudioMixerGroup musicvol;

    public void ChangeMusicVolume(float musicvolume)
    {
        musicvol.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, musicvolume));
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        button.Play();
    }
    public void Exit()
    {
        Application.Quit();
        button.Play();
    }
}
