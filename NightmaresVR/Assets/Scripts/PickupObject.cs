using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    private bool PickupItem = false;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        GameObject Player = GameObject.Find("AdvancedPlayer");
        PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
        PickupItem = playerScript.Pickup;

        if (other.gameObject.tag == "SnapPoint" && PickupItem == true)
        {
            //Debug.Log("Snapped!");
            transform.position = other.gameObject.transform.position; // set position to SnapPoint
        }
    }

}
