﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRlightsoff : MonoBehaviour {
    public GameObject Flashinglights;
    public GameObject Door;
    public GameObject Trigger;
    public AudioSource Slam;
    public AudioSource Scare;



    public void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "AdvancedPlayer":
                Flashinglights.SetActive(false);
                Door.transform.rotation = Quaternion.Euler(0, -14.179F, 90);
                Slam.Play();
                Scare.Play();
                Trigger.SetActive(false);
                break;
        }
    }
}
