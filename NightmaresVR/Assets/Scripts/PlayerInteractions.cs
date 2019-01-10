using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public Vector3 direction;
    public RaycastHit hit;
    public float maxDistance = 100;
    public LayerMask layermask;

    private Transform SnapPoint; // snapPoint for the Item
    private int scrollLimit; //Maximum times player can scroll object away/closer

    private Transform Item; // object your holding/picking up
    public bool Pickup = false; // bool for determining if to drop or hold
    public float fixedRotation = 0;
    public string ItemName = "";
    //private bool HoldingItem = false;

    private void Start()
    {
        SnapPoint = GameObject.FindGameObjectWithTag("SnapPoint").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update () {
		if(Pickup == true)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0.1)
            {

                SnapPoint.Translate(Vector3.forward * 0.5f);

                print("Mouse up");
            }
            if(Input.GetAxis("Mouse ScrollWheel") < -0.1)
            {
                SnapPoint.Translate(-Vector3.forward * 0.5f);
                print("Mouse down");
            }
        }
        if (Input.GetButtonDown("Pickup")) // F
        {
            // toggle Pickup true/false
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

            //// raycast to see what object you're attempting to pickup
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, layermask)) // Camera.main.transform.forward
            {
                //Debug.Log(hit.transform.name);
                Debug.Log(hit.transform.tag);

                if (hit.transform.gameObject.tag != "MainCamera" && hit.transform.gameObject.tag != "Player" && hit.transform.gameObject.tag != "LeftHand" && hit.transform.gameObject.tag != "RightHand" && hit.transform.gameObject.tag != "Untagged")
                {
                    // Get Reference for Item and SnapPoint
                    GameObject SnapPoint = GameObject.FindGameObjectWithTag("SnapPoint");
                    Item = hit.transform.gameObject.transform;

                    // Pickup Item
                    if ((hit.transform.gameObject.tag == "Grab" && Pickup == true)) // || (hit.transform.gameObject.tag == "Crowbar" && Pickup == true) || (hit.transform.gameObject.tag == "Key" && Pickup == true)
                    {
                        Debug.Log("Holding Item");
                        // set position to SnapPoint, Set rotation to (0,0,0) and freeze rotation
                        Item.position = SnapPoint.transform.position;
                        Item.eulerAngles = new Vector3(fixedRotation, fixedRotation, fixedRotation);
                        Item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                        ItemName = Item.name;

                            if (hit.transform.gameObject.name == "Key_1")
                            {
                                Debug.Log("Obtained Key_1");
                                Destroy(hit.transform.gameObject);
                                GameManager.Instance.Door1Locked = false;
                                print(GameManager.Instance.Door1Locked);
                                // unlock corresponding door
                            }
                            else if (hit.transform.gameObject.name == "Key_2")
                            {
                                Debug.Log("Obtained Key_2");
                                Destroy(hit.transform.gameObject);
                                GameManager.Instance.Door2Locked = false;
                                // unlock corresponding door
                            }
                            else if (hit.transform.gameObject.name == "Key_3")
                            {
                                Debug.Log("Obtained Key_3");
                                Destroy(hit.transform.gameObject);
                                GameManager.Instance.Door3Locked = false;
                                // unlock corresponding door
                            }
                            else if (hit.transform.gameObject.name == "Key_4")
                            {
                                Debug.Log("Obtained Key_4");
                                Destroy(hit.transform.gameObject);
                                GameManager.Instance.Door4Locked = false;
                                // unlock corresponding door
                            }
                    }
                    else if (Pickup == false)// Drop Item
                    {
                        Debug.Log("Droping Item");
                        Item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // remove all constraints
                    }
                    else // No Item to Pickup
                    {
                        Debug.Log("No Item to Pickup");
                        Pickup = false;
                    }
                }
                else
                {
                    Debug.Log("Hit Player Component");
                    Pickup = false; // failed to pickup an item
                }
            }
        } // end PICKUP
    } // end UPDATE
}

