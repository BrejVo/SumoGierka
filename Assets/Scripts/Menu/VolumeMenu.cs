using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeMenu : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_Text text;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        
    }

    public void ChangeVolume()
    {
        text.text = volumeSlider.value.ToString();
        audioSource.volume = volumeSlider.value / volumeSlider.maxValue;
    }

}
