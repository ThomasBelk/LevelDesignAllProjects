using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyMusicPlayer : MonoBehaviour
{
    [SerializeField] private Transform musicPlayer;
    [SerializeField] private AudioClip music;
    private bool hasPlayed = false;
    private bool shouldPlay = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldPlay = true;
        }
    }


    private void Update()
    {
        if (shouldPlay && !hasPlayed)
        {
            AudioSource.PlayClipAtPoint(music, musicPlayer.position);
            hasPlayed = true;
        }
    }
}
