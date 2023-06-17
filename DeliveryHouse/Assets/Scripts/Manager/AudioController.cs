using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip moneyClip, wrongClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CorrectRecipeSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = moneyClip;
            audioSource.Play();
        }
    }

    public void WrongRecipeSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = wrongClip;
            audioSource.Play();
        }
    }
}
