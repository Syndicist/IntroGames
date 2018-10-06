using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public PlayerSystem myPlayerSystem;
    private void Awake()
    {
        myPlayerSystem = GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>();
    }

    private void Update()
    {
        float max = 20;
        if (transform.position.x <= -max || transform.position.x >= max || transform.position.y <= -max || transform.position.y >= max)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject collisionGO = other.gameObject;
        if(collisionGO.tag == "enemy")
        {
            Destroy(collisionGO);
            Destroy(gameObject);
            myPlayerSystem.theScore++;
        }
    }
}
