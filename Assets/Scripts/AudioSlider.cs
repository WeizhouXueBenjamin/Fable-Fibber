using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class audio : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private TextMeshProUGUI ValueText;
    [SerializeField] private AudioMixMode MixMode;

    public void OnChangeSlider(float Value){
        ValueText.SetText($"{Value.ToString("N2")}");
        switch(MixMode){
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = Value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume")
                break;
        }
    }


    public enum AudioMixMode{
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
}
