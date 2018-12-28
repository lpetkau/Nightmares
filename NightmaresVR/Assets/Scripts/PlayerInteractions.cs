using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public Vector3 direction;
    public RaycastHit hit;
    public float maxDistance = 100;
    public LayerMask layermask;



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
                //Debug.Log("Pickup TRUE");
                Pickup = true;
            }
            else
            {
                //Debug.Log("Pickup FALSE");
                Pickup = false;
            }


            // do raycast
            // if raycast fails, Pickup = false

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, layermask)) // Camera.main.transform.forward
            {

                if (hit.transform.gameObject.tag != "MainCamera" && hit.transform.gameObject.tag != "Player" && hit.transform.gameObject.tag != "LeftHand" && hit.transform.gameObject.tag != "RightHand")
                {
                    Debug.Log("Hit");
                    Debug.Log(hit.distance);
                    Debug.Log(hit.transform.gameObject.tag);
                    Debug.Log(hit.transform.name);
                }
                else
                {
                    Debug.Log("Hit Player Component");
                }

            }


            //int layerMask = 10; // Layer = Grabables
            //RaycastHit hit;


            // Does the ray intersect any objects from the Grabables Layer

            //if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask)) // QueryTriggerInteraction.UseGlobal
            //{
            //    if(hit.transform.gameObject.tag != "MainCamera" && hit.transform.gameObject.tag != "Player" && hit.transform.gameObject.tag != "LeftHand" && hit.transform.gameObject.tag != "RightHand")
            //    {
            //        Debug.Log("Hit");
            //        Debug.DrawRay(transform.position, Camera.main.transform.forward, Color.yellow);
            //        Debug.Log(hit.distance);
            //        Debug.Log(hit.transform.gameObject.tag);
            //        //Destroy(hit.transform.gameObject);
            //    }
            //    else
            //    {
            //        Debug.Log("Hit Player Component");
            //    }

            //}
            //else
            //{
            //    //Debug.DrawRay(transform.position, Camera.main.transform.forward * 1000, Color.white);
            //    Debug.Log("Did not Hit");
            //    Debug.Log(hit.distance);
            //}



            //Physics.Raycast(transform.position, Camera.main.transform.forward, 0, 1000, 0);

            //Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //Vector3 Ray = transform.TransformDirection(Camera.main.transform.forward);

            //if (Physics.Raycast(transform.position, Ray, 2))
            //{
            //    print("There is something in front of the object!");
            //}


        }



	}

    void GrabItem()
    {
        GameObject Crowbar = GameObject.Find("Crowbar");
        Crowbar.transform.position = transform.position;
    }

}
