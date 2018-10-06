using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public Transform alienPrefab;

    private float nextSpawnTime;
    private float spawnRate;
    public bool spawning;
    Rigidbody erb;
    public float time;

    private void Start()
    {
        nextSpawnTime = 0.0f;
        spawnRate = 1.5f;
        spawning = true;
    }

    void Update ()
    {
        time = Time.timeSinceLevelLoad;
        if (nextSpawnTime < time && spawning)
        {
            Spawn();
            nextSpawnTime = time + spawnRate;

            //Speed up the spawnrate for the next alien
            spawnRate *= 0.98f;
            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
        }
	}

    void Spawn()
    {
        //Spawns aliens radially
        float degrees = Random.Range(0f, 360f);
        float angle = degrees * Mathf.PI/180;
        float xpos = Mathf.Cos(angle) * 15f;
        float ypos = Mathf.Sin(angle) * 15f;
        Vector3 spawnPos = transform.position + new Vector3(xpos, ypos, 0);
        var egg = Instantiate(alienPrefab, spawnPos, Quaternion.Euler(-90, 0, 0));
        
        //Forces targets to face the center of the game screen and move forward with a variable offset
        float offset = Random.Range(-3.5f, 3.5f);
        egg.LookAt(transform.position + new Vector3(offset, offset, 0));
        egg.forward = -egg.forward;
        erb = egg.GetComponent<Rigidbody>();
        erb.AddForce(-egg.forward * 5, ForceMode.Impulse);
    }
}
