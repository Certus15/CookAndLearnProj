using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Slider musicSlider, voiceSlider;
    [SerializeField]
    private AudioMixer audioMixer;

    public void SetVolume()
    {
        audioMixer.SetFloat("Music", Mathf.Log10(musicSlider.value) * 20);
        audioMixer.SetFloat("Voice", Mathf.Log10(voiceSlider.value) * 20);
    }
}
