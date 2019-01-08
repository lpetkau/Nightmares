using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door4 : MonoBehaviour {

    private Rigidbody rb;

    public bool DesiredOpen = false;
    private bool IsOpen = false;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // OPEN DOOR
        // Is Door Locked
        if (GameManager.Instance.Door4Locked == false)
        {
            if (!IsOpen && DesiredOpen)
            {
                if (count < 90)
                {
                    count += 1;
                    rb.transform.Rotate(1, 0, 0);
                }
                else
                {
                    IsOpen = true;
                    count = 0;
                }
            } // end OPEN DOOR

            // CLOSE DOOR
            if (IsOpen && !DesiredOpen)
            {
                if (count < 90)
                {
                    count += 1;
                    rb.transform.Rotate(-1, 0, 0);
                }
                else
                {
                    IsOpen = false;
                    count = 0;
                }
            } // end CLOSE DOOR
        }//end Locked door LOCK
    }// end UPDATE

    public void SetDesiredOpen()
    {
        if (GameManager.Instance.Door4Locked == false)
        {
            DesiredOpen = true;
        }
    }

    public void SetDesiredClosed()
    {
        if (GameManager.Instance.Door4Locked == false)
        {
            DesiredOpen = false;
        }
    }

    public bool CheckState()
    {

        if (IsOpen)
        {
            return true;
        }

        else
        {
            return false;
        }

    }
}
