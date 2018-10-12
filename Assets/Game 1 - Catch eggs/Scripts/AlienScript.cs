using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour
{
    private void Update()
    {
        float max = 20;
        if(transform.position.x <= -max || transform.position.x >= max || transform.position.y <= -max || transform.position.y >= max)
        {
            Destroy(gameObject);
        }
    }
}
