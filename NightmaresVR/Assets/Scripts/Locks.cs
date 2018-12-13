using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : MonoBehaviour {



    public GameObject Key;
   

    public void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Grab":

                if (collider.gameObject.name == "Key1")
                {
                    GameManager.Instance.Door1Locked = false;
                }

                else if(collider.gameObject.name == "Key2")
                {
                    GameManager.Instance.Door2Locked = false;  
                }

                break;
        }
    }
}
 