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

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
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
            }
            else
            {
                rbody.isKinematic = false;
            }
        }
        else if (PickupName == this.gameObject.name) // regular GRAB object
        {
            if (other.gameObject.tag == "SnapPoint" && PickupItem == true)
            {
                //Debug.Log("Snapped!");
                transform.position = other.gameObject.transform.position; // set position to SnapPoint (constantly)
                rbody.isKinematic = true;
            }
            else
            {
                rbody.isKinematic = false;
            }
        }
    }

    void OnTriggerExit()
    {
        Debug.Log("Update Drop Object");
        GameObject Player = GameObject.Find("AdvancedPlayer");
        PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
        PickupItem = playerScript.Pickup;
        //playerScript.Pickup = false;
        //PickupItem = false;
    }
}
