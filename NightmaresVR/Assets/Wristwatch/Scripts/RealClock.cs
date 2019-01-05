

using UnityEngine;
using System.Collections;
using System;

public class RealClock : MonoBehaviour {
	public Transform Hours;
	

	
	
	// Update is called once per frame
	void Update () {
		float hour = GameManager.Instance.MentalHealth;
		

		


		if(Hours)
			Hours.localRotation = Quaternion.Euler (0, 0, hour / 100 * 360);

	


	}
}
