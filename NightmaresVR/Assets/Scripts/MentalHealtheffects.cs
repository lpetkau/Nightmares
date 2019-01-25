using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalHealtheffects : MonoBehaviour {

    public AudioSource HeavyBreathing;
    public AudioSource Heatbeat;
    bool IsBreathingHard = false;
    bool heatbeatFast = false;


	// Update is called once per frame



	void Update () {


        //Debug.Log(GameManager.Instance.MentalHealth);


         if (GameManager.Instance.MentalHealth < 25)
        {
            heatbeatFast = true;
        }

        if (GameManager.Instance.MentalHealth < 50)
        {
            IsBreathingHard = true;
        }
        

         if (GameManager.Instance.MentalHealth > 25)
        {
            heatbeatFast = false;
        }
         if (GameManager.Instance.MentalHealth > 50)
        {
            IsBreathingHard = false;
        }

        if(heatbeatFast == true)
        {
            StartCoroutine(HeartBeatenum());
        }

        if(IsBreathingHard == true)
        {
            StartCoroutine(Breathinghardenum());
        }



    }

    IEnumerator Breathinghardenum()
    {
 
        yield return new WaitForSeconds(1);
        HeavyBreathing.Play();
        Debug.Log("HeavyBreathing");

    }
    IEnumerator HeartBeatenum()
    {

        
        HeavyBreathing.Play();
        yield return new WaitForSeconds(5);
        Debug.Log("HeartBeat");
    }
}
