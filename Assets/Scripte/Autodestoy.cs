using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestoy : MonoBehaviour
{
    public float DelayToDestroy;
    void Start()
    {
        Destroy(gameObject, DelayToDestroy);
    }

    
}
