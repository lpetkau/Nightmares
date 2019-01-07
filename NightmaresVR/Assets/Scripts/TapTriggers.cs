using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTriggers : MonoBehaviour
{

    public Transform Spawnpoint;
    public GameObject Prefab;
    public GameObject uiObject;

    void Start()
    {

        uiObject.SetActive(false);
        Prefab.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        
    
        if (other.gameObject.tag == "Player")
        {

            
            GetComponentInChildren<ParticleSystem>().Play();

            Prefab.SetActive(true);
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









