using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightlightController : MonoBehaviour {

    public GameObject Light;
    public GameObject[] charger;
    

    private float lightStrength;

    public float deathRate;
    public float chargeRate;


    private bool charging;

    

	// Use this for initialization
	void Start () {
        lightStrength = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (charging && lightStrength <= 1)
        {
            Charging();
        }
        else if (!charging && lightStrength >= 0)
        {
            Dying();
        }
        Light.GetComponent<Light>().intensity = lightStrength;

    }

    private void OnCollisionEnter(Collision other)
    {
        //check collision with nightlight
        if (charger.Length >= 1)
        {
            for (int i = 0; i < charger.Length; i++)
            {
                if (other.gameObject == charger[i])
                {
                    charging = true;
                    print("CHARGING");
                }
            }
        }
        //check other possible collisions
        
    }
    private void OnCollisionExit(Collision other)
    {
        //check collision with nightlight
        if (charger.Length >= 1)
        {
            for (int i = 0; i < charger.Length; i++)
            {
                if (other.gameObject == charger[i])
                {
                    charging = false;
                    print("Dying");
                }
            }
        }
        //check other possible collisions

    }

    private void Dying()
    {
        lightStrength -= deathRate * Time.deltaTime;
    }

    private void Charging()
    {
        lightStrength += chargeRate * Time.deltaTime;
    }
}
