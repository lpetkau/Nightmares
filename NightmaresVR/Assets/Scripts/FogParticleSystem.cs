using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogParticleSystem : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}

    