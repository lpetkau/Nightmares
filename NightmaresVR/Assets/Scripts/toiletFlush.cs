using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toiletFlush : MonoBehaviour {

    private bool flushing = false;
    public AudioSource flushingSound;

    void OnTriggerStay()
    {
        if (Input.GetButton("Interact") && !flushing)
        {
            flushing = true;
            flushingSound.Play();
            if(!IsInvoking("resetFlushing"))
            {
                Invoke("resetFlushing", 4f);
            }
        }
    }

    void resetFlushing()
    {
        flushing = false;
    }
}
