using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTriggers : MonoBehaviour
{

    public Transform Spawnpoint;
    public Rigidbody Prefab;
    public GameObject uiObject;

    void Start()
    {

        uiObject.SetActive(false);
    }

    void OnTriggerEnter()
    {
        Rigidbody RigidPrefab;
        RigidPrefab = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }
    
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(20);
        Destroy(uiObject);
        Destroy(gameObject);

    }
}









