using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    private bool CanInteract = true;
    private bool WantToOpen;

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

                GameObject Door = GameObject.Find("Door");
                Door DoorScript = Door.GetComponent<Door>();
                WantToOpen = DoorScript.DesiredOpen; // get variable from door

                // Swap between, openning and closing
                if (WantToOpen == true)
                { WantToOpen = false; }
                else
                { WantToOpen = true; }
                DoorScript.DesiredOpen = WantToOpen; // update that variable

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
