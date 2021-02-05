using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullrtScripte : MonoBehaviour
{
    public GameObject ParticuleHit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terrain") || other.gameObject.CompareTag("Ennemi"))
        {
            if (other.gameObject.CompareTag("Ennemi"))
            {
                other.gameObject.GetComponent<DamagableComponente>().TakeDamage();
            }
            Instantiate(ParticuleHit, other.contacts[0].point, Quaternion.Euler(other.contacts[0].normal));
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
