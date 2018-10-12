using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionKiller : MonoBehaviour
{
    //Destroy object once the audio is finished.
    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
            Destroy(gameObject);
    }
}
