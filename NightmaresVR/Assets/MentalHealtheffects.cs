using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalHealtheffects : MonoBehaviour {

    public AudioSource HeavyBreathing;
    public AudioSource Heatbeat;
	
	// Update is called once per frame
	void Update () {
        Debug.Log(GameManager.Instance.MentalHealth);

		if(GameManager.Instance.MentalHealth < 50)
        {
            HeavyBreathing.Play();
        }
        else if (GameManager.Instance.MentalHealth < 25)
        {
            Heatbeat.Play();
        }

        else if(GameManager.Instance.MentalHealth > 50)
        {
         
        }
	}
}
