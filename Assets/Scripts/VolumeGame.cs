using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeGame : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle volumeToggle;

    // Start is called before the first frame update
    void Start()
    {
        if(VolumeController.instance.musicsource.mute)
        {
            volumeToggle.isOn = false;
        }
        volumeSlider.value = VolumeController.instance.musicsource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        VolumeController.instance.musicsource.volume = volumeSlider.value;
    }

    public void mute()
    {
        VolumeController.instance.musicsource.mute = !volumeToggle.isOn;
    }
}
