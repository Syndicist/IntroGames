using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionKiller : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        Destroy(gameObject, 2);
    }
}
