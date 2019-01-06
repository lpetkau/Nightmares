using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrLights : MonoBehaviour {
    public GameObject BathLights;
    public bool Isrunning = false;

    IEnumerator Flicker()
    {
       
        Isrunning = true;
        float num = Random.Range(.05f, .2f);
        BathLights.SetActive(false);
        yield return new WaitForSeconds(num);
         num = Random.Range(.05f, .2f);
        BathLights.SetActive(true);
        yield return new WaitForSeconds(num);
        num = Random.Range(.05f, .5f);
        BathLights.SetActive(false);
        yield return new WaitForSeconds(num);
         num = Random.Range(.05f, .2f);
        BathLights.SetActive(true);
        yield return new WaitForSeconds(num);
         num = Random.Range(.05f, .2f);
        Isrunning = false;
    }
    // Update is called once per frame
    void Update () {
        if (Isrunning == false) {
        StartCoroutine(Flicker());

        }
    }
}
