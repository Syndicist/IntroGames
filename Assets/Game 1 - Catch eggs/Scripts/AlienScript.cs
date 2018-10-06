using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour
{
    PlayerSystem myPlayerSystem;

    private void Awake()
    {
        myPlayerSystem = GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>();
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
