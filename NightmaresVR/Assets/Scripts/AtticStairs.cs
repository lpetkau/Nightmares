using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticStairs : MonoBehaviour {

    public AudioSource atticStairs;
    //public AudioSource atticEndOpening;

    public Transform TopTeleport;
    public Transform BotTeleport;
    private bool TeleToTop = true;
    private bool TeleportEnabled = false;
    private bool DelayActive = false;

    private bool TopState;
    private bool BotState;

    public void CrowbarInteract()
    {
        Debug.Log("Crowbar Interaction");
        TopState = this.gameObject.GetComponentInChildren<Stairs_Top>().CheckState();
        BotState = this.gameObject.GetComponentInChildren<Stairs_Bot>().CheckState();

        if (TopState == false)
        {
            this.gameObject.GetComponentInChildren<Stairs_Top>().SetDesiredOpen();
            Invoke("EnableTeleport", 2.0f);
           // Invoke("PlaySound", 0.5f);
            atticStairs.Play();

        }
        else if (TopState == true)
        {
            //this.gameObject.GetComponentInChildren<Stairs_Top>().SetDesiredClosed();
        }

        if (BotState == false)
        {
            this.gameObject.GetComponentInChildren<Stairs_Bot>().SetDesiredOpen();
        }
        else if (BotState == true)
        {
            //this.gameObject.GetComponentInChildren<Stairs_Bot>().SetDesiredClosed();
        }
    }

    void OnTriggerStay()
    {
        
        if (Input.GetButton("Interact") && TeleportEnabled == true)
        {
            if (DelayActive == false)
            {
                DelayActive = true;
                if (TeleToTop == true)
                {
                    Debug.Log("Walk-Up Stairs");
                    TeleToTop = false;
                    GameObject Player = GameObject.Find("AdvancedPlayer");
                    Player.transform.position = TopTeleport.position;
                }
                else // TeleToTop == false
                {
                    Debug.Log("Walk-Down Stairs");
                    TeleToTop = true;
                    GameObject Player = GameObject.Find("AdvancedPlayer");
                    Player.transform.position = BotTeleport.position;
                }
            }
            else // DelayActive == true
            {
                if (!IsInvoking("ResetDelay")) 
                {
                    Invoke("ResetDelay", 0.5f);
                }
            }
        }
    }

    public void EnableTeleport()
    {
        TeleportEnabled = true;
    }

    void ResetDelay()
    {
        DelayActive = false;
    }

    //void PlaySound()
    //{
    //    atticEndOpening.Play();
    //}

}
