using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : MonoBehaviour {



    public GameObject Key;
    public int DoorNumber;

    public void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "Key1":
                // Door1
                if (collider.gameObject.name == "Key1"  &&  DoorNumber == 1)
                {
                    GameManager.Instance.Door1Locked = false;
                     Debug.Log("GameManager.Instance.Door1Locked");
                }

                break;

            case "Key2":
                // Door1
                if (collider.gameObject.name == "Key2" && DoorNumber == 1)
                {
                   
                    Debug.Log("wrong door");
                }

                break;
        }
    }
}
 