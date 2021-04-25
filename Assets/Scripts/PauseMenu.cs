using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pause;

    public AudioMixerGroup musicvol;
    public AudioMixerGroup effectcvol;

    void Start()
    {
        pause.SetActive(false);
    }

    public void ChangeMusicVolume(float musicvolume)
    {
        musicvol.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, musicvolume));
    }

    public void ChangeEffectVolume(float effectvolume)
    {
        effectcvol.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, effectvolume));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
