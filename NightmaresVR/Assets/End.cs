using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{

    public void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "AdvancedPlayer":
                SceneManager.LoadScene("mAINmENu");
                break;
        }
    }
}


