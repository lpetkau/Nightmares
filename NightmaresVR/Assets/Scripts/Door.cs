using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Rigidbody rb;
    
    public bool DesiredOpen = false;
    private bool IsOpen = false;
    private int count = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // OPEN DOOR
        if(!IsOpen && DesiredOpen)
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

    }
}
