using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticStairs : MonoBehaviour {

    private bool TopState;
    private bool BotState;

    //void OnTriggerEnter(Collision other)
    //{
    //    if(other.gameObject.tag == "Crowbar")
    //    {
    //        Debug.Log("Crowbar Interaction");
    //        TopState = this.gameObject.GetComponentInChildren<Stairs_Top>().CheckState();
    //        BotState = this.gameObject.GetComponentInChildren<Stairs_Bot>().CheckState();

    //        if (TopState == false)
    //        {
    //            this.gameObject.GetComponentInChildren<Stairs_Top>().SetDesiredOpen();
    //        }
    //        else if (TopState == true)
    //        {
    //            this.gameObject.GetComponentInChildren<Stairs_Top>().SetDesiredClosed();
    //        }

    //        if (BotState == false)
    //        {
    //            this.gameObject.GetComponentInChildren<Stairs_Bot>().SetDesiredOpen();
    //        }
    //        else if (BotState == true)
    //        {
    //            this.gameObject.GetComponentInChildren<Stairs_Bot>().SetDesiredClosed();
    //        }
    //    }
    //}

    public void CrowbarInteract()
    {
        Debug.Log("Crowbar Interaction");
        TopState = this.gameObject.GetComponentInChildren<Stairs_Top>().CheckState();
        BotState = this.gameObject.GetComponentInChildren<Stairs_Bot>().CheckState();

        if (TopState == false)
        {
            this.gameObject.GetComponentInChildren<Stairs_Top>().SetDesiredOpen();
        }
        else if (TopState == true)
        {
            this.gameObject.GetComponentInChildren<Stairs_Top>().SetDesiredClosed();
        }

        if (BotState == false)
        {
            this.gameObject.GetComponentInChildren<Stairs_Bot>().SetDesiredOpen();
        }
        else if (BotState == true)
        {
            this.gameObject.GetComponentInChildren<Stairs_Bot>().SetDesiredClosed();
        }
    }

}
