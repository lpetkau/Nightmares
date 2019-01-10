using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    public bool PickupItem = false;
    public string PickupName = "";
    //private bool HyperSnap = false;

    private Rigidbody rb;
    Transform SnapPoint;
    Transform KeyRing;

    public bool canGrab = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        if(this.gameObject.name == "Vent")
        {
            canGrab = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject Player = GameObject.Find("AdvancedPlayer");
        PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
        PickupItem = playerScript.Pickup;
        PickupName = playerScript.ItemName;
        GameObject SnapPoint = GameObject.FindGameObjectWithTag("SnapPoint");
        GameObject KeyRing = GameObject.FindGameObjectWithTag("KeyRing");
        Rigidbody rbody = GetComponent<Rigidbody>();

        if (PickupName == this.gameObject.name && (this.gameObject.name == "Key_1" || this.gameObject.name == "Key_2" || this.gameObject.name == "Key_3" || this.gameObject.name == "Key_4"))
        {
            if (other.gameObject.tag == "KeyRing" && PickupItem == true)
            {
                //Debug.Log("Snapped!");
                transform.position = other.gameObject.transform.position; // set position to SnapPoint (constantly)
                rbody.isKinematic = true;
                this.transform.parent = SnapPoint.transform;
            }
            else
            {
                rbody.isKinematic = false;
                this.transform.parent = null;
            }
        }
        else if (PickupName == this.gameObject.name && canGrab) // regular GRAB object
        {
            if (other.gameObject.tag == "SnapPoint" && PickupItem == true)
            {
                //Debug.Log("Snapped!");
                transform.position = other.gameObject.transform.position; // set position to SnapPoint (constantly)
                rbody.isKinematic = true;
                this.transform.parent = SnapPoint.transform;
            }
            else
            {
                rbody.isKinematic = false;
                this.transform.parent = null;
            }
        }
    }

    void OnTriggerExit()
    {
        
        GameObject Player = GameObject.Find("AdvancedPlayer");
        PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
        PickupItem = playerScript.Pickup;
        //playerScript.Pickup = false;
        //PickupItem = false;
    }
}
