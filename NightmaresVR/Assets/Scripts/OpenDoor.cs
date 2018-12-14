using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    private bool CanInteract = true;
    private bool IsOpen = true;
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButton("Interact") && CanInteract == true)
            {
                Debug.Log("Interact with Door");

                // cannot spam interact
                CanInteract = false;
                Invoke("ResetDoorInteract", 1f);

                // get its current state
                IsOpen = this.gameObject.GetComponentInParent<Door>().CheckState();

                if (IsOpen == false)
                {
                    //Debug.Log("Open");
                    this.gameObject.GetComponentInParent<Door>().SetDesiredOpen();
                }
                else if (IsOpen == true)
                {
                    //Debug.Log("Close");
                    this.gameObject.GetComponentInParent<Door>().SetDesiredClosed();
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ResetDoorInteract()
    {
        CanInteract = true;
    }

}
