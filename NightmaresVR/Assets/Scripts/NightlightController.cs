using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightlightController : MonoBehaviour {

    public GameObject Light;
    public GameObject[] charger;
    

    private float lightStrength;

    bool Playedonce = false;
    public float deathRate;
    public float chargeRate;
    public GameObject Spidey;
    public GameObject Spidey1;
    public AudioSource Dock;
    public AudioSource SpiderDeath;

    private bool charging;

    

	// Use this for initialization
	void Start () {
        lightStrength = 0;
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(lightStrength);
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
                    Dock.Play();
                }
                if (other.gameObject == charger[2] && Playedonce == false)
                {

                    SpiderDeath.Play();
                      charging = true;
                    Spidey.SetActive(false);
                    Spidey1.SetActive(false);
                    Playedonce = true;
                   
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
                    Dock.Play();
                }

                if (other.gameObject == charger[0])
                {
                    charging = false;
                    GameManager.Instance.Door1Locked = false;

                    


                }
            }
        }
        //check other possible collisions

    }

    private void Dying()
    {
        lightStrength -= deathRate * Time.deltaTime / 13;
    }

    private void Charging()
    {
        lightStrength += chargeRate * Time.deltaTime;
    }
}
