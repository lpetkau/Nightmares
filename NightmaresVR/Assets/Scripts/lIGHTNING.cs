using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lIGHTNING : MonoBehaviour {
    private var Timer(float);

    void start()
    {
        // Add a random value of time to the Timer instead of a fixed value of 4
        Timer = Time.time + Random.Range(1, 6);
    }

    void Update()
    {
        Debug.Log(Timer);
        var randNum = Random.Range(0, 3); // this will return a number between 0 and 9 

        if (Timer < Time.time)
        {

            // Add a random value of time to the Timer instead of a fixed value of 4
            Timer = Time.time + Random.Range(1, 10);
            
        }
    }
}
