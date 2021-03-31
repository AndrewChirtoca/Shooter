using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClipRandomizer : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clips;

    public void PlayRandomClip()
    {
        int randomIndex = Random.Range(0, clips.Count);
        audioSource.clip = clips[randomIndex];
        audioSource.Play();
    }
}
