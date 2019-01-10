

using UnityEngine;
using System.Collections;
using System;

public class RealClock : MonoBehaviour {
	public Transform Hours;

    GameObject watch;
    GameObject watchSlot;
    GameObject rightHand;

    private void Start()
    {

        watch = this.gameObject;
        watchSlot = GameObject.FindGameObjectWithTag("WatchSlot");
        rightHand = GameObject.FindGameObjectWithTag("RightHand");

        if (GameManager.Instance.VRConnected)
        {
            watch.transform.parent = rightHand.transform;
        }
        else
            watch.transform.parent = watchSlot.transform;
    }

    // Update is called once per frame
    void Update () {
		float hour = GameManager.Instance.MentalHealth;
		

		


		if(Hours)
			Hours.localRotation = Quaternion.Euler (0, 0, hour / 100 * 360);

	


	}
}
