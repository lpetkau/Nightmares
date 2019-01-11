using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charger : MonoBehaviour {

    public Transform ChargerSnapPoint;
    public GameObject Nightlight;
    private bool PickupNightlight;
    private bool recentlySnapped = false;

    void OnTriggerStay(Collider other)
    {
        GameObject Player = GameObject.Find("AdvancedPlayer");
        PlayerInteractions playerScript = Player.GetComponent<PlayerInteractions>();
        PickupNightlight = playerScript.Pickup;

        if (other.gameObject.name == "NIGHTLIGHT" && !PickupNightlight && recentlySnapped == false)
        {
            Debug.Log("Nightlight Snapped");
            Nightlight.transform.position = ChargerSnapPoint.position;
            Nightlight.transform.eulerAngles = new Vector3(0, 0, 0);
            Nightlight.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        else if (other.gameObject.name == "NIGHTLIGHT" && PickupNightlight)
        {
            recentlySnapped = true;
            Invoke("ResetRecentlySnapped", 1f);
        }
    }

    void OnTriggerLeave(Collider other)
    {
        if (other.gameObject.name == "NIGHTLIGHT")
        {
            Nightlight.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    void ResetRecentlySnapped()
    {
        recentlySnapped = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
