using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour
{
    
    private AudioSource myAudioSource;
    public AudioClip[] dieSounds;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();

        int index = Random.Range(0, dieSounds.Length);
        myAudioSource.clip = dieSounds[index];
        
    }
    private void Update()
    {
        float max = 20;
        if(transform.position.x <= -max || transform.position.x >= max || transform.position.y <= -max || transform.position.y >= max)
        {
            Destroy(gameObject);
        }
    }
}
