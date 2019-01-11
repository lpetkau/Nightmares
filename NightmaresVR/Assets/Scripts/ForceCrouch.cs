using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCrouch : MonoBehaviour {

    private bool Crouching;

    void OnTriggerStay(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "AdvancedPlayer":
               GameObject Player = GameObject.Find("AdvancedPlayer");
                vp_FPInput playerScript = Player.GetComponent<vp_FPInput>();
                Player.GetComponent<vp_FPInput>().FPPlayer.Crouch.TryStart();
                break;
        }
    }

    void OnTriggerLeave(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "AdvancedPlayer":
                GameObject Player = GameObject.Find("AdvancedPlayer");
                vp_FPInput playerScript = Player.GetComponent<vp_FPInput>();
                Player.GetComponent<vp_FPInput>().FPPlayer.Crouch.TryStop();
                break;
        }
    }

}
