using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTriggers : MonoBehaviour
{

    public Transform Spawnpoint;
    public GameObject Prefab;
    public GameObject uiObject;
    public GameObject uiObject2;
    public GameObject blood;

    void Start()
    {

    

       uiObject.SetActive(false);
        Prefab.SetActive(false);
        uiObject2.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        
    
        if (other.gameObject.tag == "Player")
        {

            
            GetComponentInChildren<ParticleSystem>().Play();

            Prefab.SetActive(true);
            uiObject.SetActive(true);
            uiObject2.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        blood.SetActive(true);
        yield return new WaitForSeconds(10);
        Destroy(uiObject);
        Destroy(uiObject2);
        Destroy(gameObject);
        
        yield return new WaitForSeconds(5);
        blood.SetActive(true);

    }
}









