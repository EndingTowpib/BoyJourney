using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMController : MonoBehaviour
{
    public static BGMController instance { private set; get; }
    private AudioSource audioSource;
    //private GameObject UI_BGM;
    private Button volumeBtn;
    private GameObject onImage;
    private GameObject offImage;
    private void Awake()
    {
        instance = this;
        //UI_BGM = GameObject.FindWithTag("BGMController");
        volumeBtn = GameObject.FindWithTag("VolumeBtn").GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        onImage = Instantiate(Resources.Load("MusicOn") as GameObject);
        offImage= Instantiate(Resources.Load("MusicOff") as GameObject);
        if (!PlayerPrefs.HasKey("Mute"))
        {
            PlayerPrefs.SetInt("Mute", 0);
        }
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", 1f);
        }
        else
        {
            if(PlayerPrefs.GetInt("Mute") == 1)
            {
                audioSource.volume = 0f;
                volumeBtn.image.sprite = offImage.GetComponent<Image>().sprite;
            }
            else
            {
                audioSource.volume = PlayerPrefs.GetFloat("BGMVolume");
                volumeBtn.image.sprite = onImage.GetComponent<Image>().sprite;
            }
        }
        
        //UI_BGM.GetComponent<Slider>().value = audioSource.volume;
    }
    public void SetVolume()
    {
        //audioSource.volume = UI_BGM.GetComponent<Slider>().value;
        if (PlayerPrefs.HasKey("Mute"))
        {
            audioSource.volume = PlayerPrefs.GetInt("Mute") == 1 ? 0f : PlayerPrefs.GetFloat("BGMVolume");
        }
        else audioSource.volume = PlayerPrefs.GetFloat("BGMVolume");
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("BGMVolume", audioSource.volume);
    }
    public void TurnVolume()
    {
        int temp = PlayerPrefs.GetInt("Mute");
        Image i=volumeBtn.GetComponent<Image>();
        if (temp == 0)
        {
            PlayerPrefs.SetInt("Mute", 1);
            i.sprite = offImage.GetComponent<Image>().sprite;
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 0);
            i.sprite = onImage.GetComponent<Image>().sprite;
        }
        SetVolume();
    }
}
