using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    private ButtonBehavior _buttonBehavior;

    private void Awake()
    {
        _buttonBehavior = GetComponent<ButtonBehavior>();
    }

    private void Start()
    {
        if(_playableDirector != null)
        {
            _playableDirector.stopped += OnCutsceneEnd;
        }
    }

    private void OnCutsceneEnd(PlayableDirector director)
    {
        _buttonBehavior.PlayGame();
    }
}
