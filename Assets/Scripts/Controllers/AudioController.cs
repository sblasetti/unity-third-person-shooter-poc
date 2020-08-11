using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] float delayBetweenClips;

    bool canPlay;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (!canPlay) return;

        GameManager.GetInstance().GetTimer().Add(delayBetweenClips, () => {
            canPlay = true;
        });

        canPlay = false;
        var random = UnityEngine.Random.Range(0, clips.Length);
        source.PlayOneShot(clips[random]);
    }
}
