using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SEFScriptPouse : MonoBehaviour
{

    public AudioMixerGroup effectsvol;


    public void ChangeEffectsVolume(float sfvolume)
    {
        effectsvol.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, sfvolume));
    }
}
