using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public Vector3 direction;
    public RaycastHit hit;
    public float maxDistance = 100;
    public LayerMask layermask;

    public Transform SnapPoint_1; // snapPoint for the Item
    public Transform SnapPoint_2; // snapPoint for the Item while lifted
    public Transform Item; // object your holding/picking up
    public Rigidbody ItemRB; // Rigidbody of Picked-Up Item
    public bool Pickup = false; // bool for determining if to drop or hold
    public float fixedRotation = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButtonDown("Pickup")) // F
        {
            // toggle Pickup true/false
            if(Pickup == false)
            {
                //Debug.Log("Pickup TRUE");
                Pickup = true;
            }
            else
            {
                //Debug.Log("Pickup FALSE");
                Pickup = false;
            }

            // raycast to see what object you're attempting to pickup
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, layermask)) // Camera.main.transform.forward
            {
                if (hit.transform.gameObject.tag != "MainCamera" && hit.transform.gameObject.tag != "Player" && hit.transform.gameObject.tag != "LeftHand" && hit.transform.gameObject.tag != "RightHand")
                {
                    //Debug.Log("Hit");
                    //Debug.Log(hit.distance);
                    //Debug.Log(hit.transform.gameObject.tag);
                    //Debug.Log(hit.transform.name);

                    // Pickup Item
                    if (hit.transform.gameObject.tag == "Crowbar" && Pickup == true)
                    {
                        //Debug.Log("Holding Item");
                        // Get Reference for Item and SnapPoint
                        SnapPoint_1 = this.gameObject.transform.GetChild(3);
                        Item = hit.transform.gameObject.transform;

                        // set position to SnapPoint, Set rotation to (0,0,0) and freeze rotation
                        Item.position = SnapPoint_1.transform.position;
                        Item.eulerAngles = new Vector3(fixedRotation, fixedRotation, fixedRotation);
                        Item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    }
                    else // Drop Item
                    {
                        //Debug.Log("Droping Item");
                        Item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    }
                }
                else
                {
                    Debug.Log("Hit Player Component");
                    Pickup = false; // failed to pickup an item
                }
            }
        } // end PICKUP

        //if (Input.GetButtonDown("Lift")) // LMB
        //{
        //    Debug.Log("Lift");
        //    SnapPoint_2 = this.gameObject.transform.GetChild(4);
        //    Item.position = SnapPoint_2.transform.position;
        //}

        //if (Input.GetButtonUp("Lift")) // LMB
        //{
        //    Debug.Log("Un-Lift");
        //    Item.position = SnapPoint_1.transform.position;
        //}

    } // end UPDATE

}
