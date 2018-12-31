﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_Top : MonoBehaviour {

    private Rigidbody rb;

    public bool DesiredOpen = false;
    private bool IsOpen = false;
    private int count = 0;
    private bool isActive = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //RAISE Stairs
        if (!IsOpen && DesiredOpen)
        {
            if (count < 120)
            {
                isActive = true;
                count += 1;
                rb.transform.Rotate(-0.5f, 0, 0);
            }
            else
            {
                isActive = false;
                IsOpen = true;
                count = 0;
            }
        } // end RAISE Stairs

        // LOWER Stairs
        if (IsOpen && !DesiredOpen)
        {
            if (count < 120)
            {
                isActive = true;
                count += 1;
                rb.transform.Rotate(0.5f, 0, 0);
            }
            else
            {
                isActive = false;
                IsOpen = false;
                count = 0;
            }
        } // end LOWER Stairs
    }

    //void OnTriggerEnter(Collider other)
    //{

    //}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive == true)
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), other.gameObject.GetComponent<CharacterController>()); // player ignore Stairs
        }
        else if (other.gameObject.tag == "Player" && isActive == false)
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), other.gameObject.GetComponent<CharacterController>(), false); // player stop ignoring Stairs
        }

        if (other.gameObject.tag == "Stairs")
        {
            //Debug.Log("Stairs");
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>()); // Stairs ignore itself
        }

        if (other.gameObject.tag == "Crowbar" && isActive == true)
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>()); // Stairs ignore Crowbar
        }
        else if (other.gameObject.tag == "Crowbar")
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>(), false); // Stairs stop ignoring Crowbar
            this.gameObject.GetComponentInParent<AtticStairs>().CrowbarInteract();
        }
    }

    public void SetDesiredOpen()
    {
        DesiredOpen = true;
    }

    public void SetDesiredClosed()
    {
        DesiredOpen = false;
    }

    public bool CheckState()
    {
        if (IsOpen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
