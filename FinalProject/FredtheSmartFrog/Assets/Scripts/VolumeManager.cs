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
    }

    private void Update()
    {
        audioSrc.volume = musSlider.value;
        AudioListener.volume = masSlider.value;
    }
}
