using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInterfaceAudio : MonoBehaviour
{
    public static UseInterfaceAudio instance { private set; get; }
    public AudioClip charDeath;
    public AudioClip charJump;
    public AudioClip goSavepoint;
    public AudioClip chestOpen;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
