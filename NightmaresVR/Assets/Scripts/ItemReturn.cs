using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReturn : MonoBehaviour {

    private float ItemRotation;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crowbar" || other.tag == "Grab")
        {
            GameObject Player = GameObject.Find("AdvancedPlayer");
            PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
            playerScript.Pickup = true; // activate SnapPoint
            ItemRotation = playerScript.fixedRotation;
            
            other.transform.parent.position = Player.transform.GetChild(3).position; // move item to SnapPoint
            other.transform.parent.eulerAngles = new Vector3(ItemRotation, ItemRotation, ItemRotation);
            other.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

}
