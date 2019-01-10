using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vent : MonoBehaviour {

    public AudioSource VentFall;
    bool PlayedOnce = false;
	
	// Update is called once per frame
	void Update () {
       

		if(GameManager.Instance.BRScrews == 4)
        {
         
           
            gameObject.tag = "Grab";
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                 if (PlayedOnce == false)
        {
            VentFall.Play();
            PlayedOnce = true;
        }
         
        }
	}
 
}
