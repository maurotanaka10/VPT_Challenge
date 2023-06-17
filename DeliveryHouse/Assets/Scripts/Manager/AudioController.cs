using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _moneyClip, _wrongClip, _catchClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void CorrectRecipeSound()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = _moneyClip;
            _audioSource.Play();
        }
    }

    public void WrongRecipeSound()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = _wrongClip;
            _audioSource.Play();
        }
    }

    public void CatchSomethingSound()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = _catchClip;
            _audioSource.Play();
        }
    }
}
