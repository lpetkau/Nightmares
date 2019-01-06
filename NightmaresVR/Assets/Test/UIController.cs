using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text leftVeloc;
    public Text rightVeloc;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        leftVeloc.text = "Left: " + GameManager.Instance.leftHandVelocity;
        rightVeloc.text = "Right: " + GameManager.Instance.rightHandVelocity;

    }
}
