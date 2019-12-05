using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private AudioSource audioSrc;

    public Slider masSlider;
    public Slider musSlider;
    public Slider soundSlider;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        masSlider.value = PlayerPrefs.GetFloat("Master");
        musSlider.value = PlayerPrefs.GetFloat("Music");
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
    }

    private void Update()
    {
        audioSrc.volume = musSlider.value;
        AudioListener.volume = masSlider.value;
        PlayerPrefs.SetFloat("Master", masSlider.value);
        PlayerPrefs.SetFloat("Music", musSlider.value);
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
    }
}
