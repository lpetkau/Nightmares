using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class PlayerMovement : MonoBehaviour {
   

    public float playerSpeed;
    

    

    // Use this for initialization
    void Start () {
		if(playerSpeed == 0f)
        {
            playerSpeed = 50f;
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        var h = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var v = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        

        transform.Translate(h, 0, v);

        

        //save the current position for calculation of velocity in next frame
        
    }
}
