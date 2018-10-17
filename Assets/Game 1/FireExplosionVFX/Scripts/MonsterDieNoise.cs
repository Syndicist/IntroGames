using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDieNoise : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip[] dieSounds;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();

        int index = Random.Range(0, dieSounds.Length);
        myAudioSource.clip = dieSounds[index];
        myAudioSource.Play();
    }
}
