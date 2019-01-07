using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReturn : MonoBehaviour {

    private float ItemRotation;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key" || other.tag == "Grab")
        {
            GameObject Player = GameObject.Find("AdvancedPlayer");
            PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
            playerScript.Pickup = true; // activate SnapPoint
            ItemRotation = playerScript.fixedRotation;

            if (transform.parent != null) // Null Reference Exeption causes item to fall through floor
            {
                other.transform.parent.position = Player.transform.Find("SnapPoint").position; // move item to SnapPoint
                other.transform.parent.eulerAngles = new Vector3(ItemRotation, ItemRotation, ItemRotation);
                other.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                other.transform.position = Player.transform.Find("SnapPoint").position; // move item to SnapPoint
                other.transform.eulerAngles = new Vector3(ItemRotation, ItemRotation, ItemRotation);
                other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            
        }
    }

}
