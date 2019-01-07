using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    private bool PickupItem = false;
    private bool HyperSnap = false;

    private Rigidbody rb;
    Transform SnapPoint;
    Transform KeyRing;

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
        SnapPoint = Player.transform.Find("SnapPoint");
        KeyRing = Player.transform.Find("KeyRing");
        //SnapPoint = Player.transform.GetChild(6); // Advanced Player 1st child
        //KeyRing = Player.transform.GetChild(7); // Advanced Player 2nd child


        if (this.gameObject.tag == "Key")
        {
            if (other.gameObject.tag == "KeyRing" && PickupItem == true)
            {
                //Debug.Log("Snapped!");
                transform.position = other.gameObject.transform.position; // set position to SnapPoint (constantly)
                HyperSnap = true;
            }
            else if (HyperSnap == true && PickupItem == true)
            {
                transform.position = KeyRing.position;
            }
            else
            {
                HyperSnap = false;
            }
        }
        else
        {
            if (other.gameObject.tag == "SnapPoint" && PickupItem == true)
            {
                //Debug.Log("Snapped!");
                transform.position = other.gameObject.transform.position; // set position to SnapPoint (constantly)
                HyperSnap = true;
            }
            else if (HyperSnap == true && PickupItem == true)
            {
                transform.position = SnapPoint.position;
            }
            else
            {
                HyperSnap = false;
            }
        }
    }
}
