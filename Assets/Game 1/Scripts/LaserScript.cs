using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public Transform monsterExplosionPrefab;
    public PlayerSystem myPlayerSystem;
    private AudioSource myAudioSource;
    public MeshRenderer myMeshRenderer;
    public BoxCollider myBoxCollider;
    public AudioClip[] laserSounds;

    private void Awake()
    {
        myPlayerSystem = GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>();
        myMeshRenderer = GetComponent<MeshRenderer>();
        myBoxCollider = GetComponent<BoxCollider>();
        myAudioSource = GetComponent<AudioSource>();

        int index = Random.Range(0, laserSounds.Length);
        myAudioSource.clip = laserSounds[index];
        myAudioSource.Play();
    }

    private void Update()
    {
        float max = 20;
        if (transform.position.x <= -max || transform.position.x >= max || transform.position.y <= -max || transform.position.y >= max)
        {
            Destroy(gameObject);
        }
        if (!myAudioSource.isPlaying && !myMeshRenderer.enabled)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject collisionGO = other.gameObject;
        if(collisionGO.tag == "enemy")
        {
            Destroy(collisionGO);
            myMeshRenderer.enabled = false;
            myBoxCollider.enabled = false;
            myPlayerSystem.theScore++;
            Instantiate(monsterExplosionPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}
