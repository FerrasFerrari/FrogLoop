using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumesettings : MonoBehaviour
{
    [SerializeField] private AudioMixer MyMixer;
    [SerializeField] private Slider generalSlider;


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
        float volume = generalSlider.value;
        MyMixer.SetFloat("general", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumeGeneral", volume);
        PlayerPrefs.Save();
    }
    private void VolumeLoad()

    {
        generalSlider.value = PlayerPrefs.GetFloat("VolumeGeneral");
        SetVolumeGeneral();
    }
    
}
