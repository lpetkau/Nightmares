using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRlightsoff : MonoBehaviour {
    public GameObject Flashinglights;


    public void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "AdvancedPlayer":
                Flashinglights.SetActive(false);
                break;
        }
    }
}
