using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumesettings : MonoBehaviour
{
    [SerializeField] private AudioMixer MyMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;


    private void Start()
    {

        if (PlayerPrefs.HasKey("VolumeGeneral"))
       {
            VolumeLoad();
       }
        else
       {
            SetVolumeGeneral();
        }

    }
    public class AudioSettings
    {
        public float VolumeGeneral;
    }
    public void SetVolumeGeneral()
    {
        float volume = musicSlider.value;
        MyMixer.SetFloat("general", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumeGeneral", volume);
        PlayerPrefs.Save();
    }
    private void VolumeLoad()

    {
        SFXSlider.value = PlayerPrefs.GetFloat("VolumeGeneral");
        SetVolumeGeneral();
    }
    
}
