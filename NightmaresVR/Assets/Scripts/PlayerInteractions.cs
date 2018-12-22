using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public bool Pickup = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButtonDown("Pickup"))
        {
            // Swap Pickup true/false
            if(Pickup == false)
            {
                Debug.Log("Pickup TRUE");
                Pickup = true;
            }
            else
            {
                Debug.Log("Pickup FALSE");
                Pickup = false;
            }


            // do raycast
            // if raycast fails, Pickup = false
        }



	}

    void GrabItem()
    {

    }

}
