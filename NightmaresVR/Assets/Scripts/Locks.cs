using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : MonoBehaviour {



    public GameObject Key;
    public int DoorNumber;

    public void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Grab":
                // Door1
                if (collider.gameObject.name == "Key1"  &&  DoorNumber == 1)
                {
                    GameManager.Instance.Door1Locked = false;
                    Debug.Log("Unlock");
                }

                else if(collider.gameObject.name == "Key2" && DoorNumber == 1)
                {
                    GameManager.Instance.Door2Locked = false;
                    Debug.Log("wrong Key");
                }
                //Door2
                if (collider.gameObject.name == "Key1" && DoorNumber == 2)
                {
                    GameManager.Instance.Door1Locked = false;
                    Debug.Log("wrong Key");
                }

                else if (collider.gameObject.name == "Key2" && DoorNumber == 2)
                {
                    GameManager.Instance.Door2Locked = false;
                    Debug.Log("Unlock");
                }

                break;
        }
    }
}
 