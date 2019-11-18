using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementSound : MonoBehaviour
{
    [Header("Resources", order = 0)]
    public AudioClip buttonClickSound;
    public AudioClip buttonHoverSound;
    public AudioClip cookingSound;
    public AudioClip tooLateSound;
    public AudioClip onTimeSound;

    [Header("Settings", order = 1)]
    public bool buttonClickEnabled;
    public bool buttonHoverEnabled;
    public bool cookingSoundEnabled;
    public bool tooLateSoundEnabled;
    public bool onTimeSoundEnabled;

    private AudioSource buttonCickSource { get { return GetComponent<AudioSource>(); } }
    private AudioSource buttonHoverSource { get { return GetComponent<AudioSource>(); } }
    private AudioSource cookingSoundSource { get { return GetComponent<AudioSource>(); } }
    private AudioSource tooLateSource { get { return GetComponent<AudioSource>(); } }
    private AudioSource onTimeSource { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();

        buttonCickSource.clip = buttonClickSound;
        buttonHoverSource.clip = buttonHoverSound;

        cookingSoundSource.clip = cookingSound;
        tooLateSource.clip = tooLateSound;
        onTimeSource.clip = onTimeSound;

        buttonCickSource.playOnAwake = false;
        buttonHoverSource.playOnAwake = false;
        cookingSoundSource.playOnAwake = false;
        tooLateSource.playOnAwake = false;
        onTimeSource.playOnAwake = false;
    }
}
