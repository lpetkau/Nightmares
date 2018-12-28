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
        //if (Input.GetButton("Pickup"))
        //{
        //    // drop item  
        //}

        GameObject Player = GameObject.Find("AdvancedPlayer");
        PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
        PickupItem = playerScript.Pickup;

        if (other.gameObject.tag == "SnapPoint" && PickupItem == true)
        {
            Debug.Log("Snapped!");
            transform.position = other.gameObject.transform.position; // set position to SnapPoint
        }

    //    if (other.gameObject.tag == "Grab")
    //    {
    //        Debug.Log("Grab Snap");
    //        other.transform.parent.gameObject.transform.position = transform.position; // set it's parent's position to the snap point
    //    }

    //    if (other.gameObject.tag == "Crowbar")
    //    {
    //        Debug.Log("Crowbar Snap");
    //        //other.transform.parent.gameObject.transform.position = transform.position; // set it's parent's position to the snap point
    //        other.gameObject.transform.position = transform.position;
    }

}
