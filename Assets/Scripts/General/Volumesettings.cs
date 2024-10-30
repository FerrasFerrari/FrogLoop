using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumesettings : MonoBehaviour
{
    [SerializeField] private AudioMixer MyMixer;
    [SerializeField] private Slider generalSlider;
    public void SetVolumeGeneral()
    {
        float volume = generalSlider.value;
        MyMixer.SetFloat("general", volume);
    }
}
