using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mentalHealth1 : MonoBehaviour {
    public bool Active = true;

    IEnumerator Counter()
    {
      
            Active = false;
            yield return new WaitForSeconds(1);
        if (GameManager.Instance.MentalHealth < 100)
        {
            GameManager.Instance.MentalHealth += 1;
        }
            Active = true;
        
    }


    void Update () {
        Debug.Log(GameManager.Instance.MentalHealth);

       if(GameManager.Instance.MentalHealth > 100)
        {
            GameManager.Instance.MentalHealth = 100;
        }


        if (Active == true && GameManager.Instance.MentalHealth <= 100)
        {
             StartCoroutine(Counter());
            
        }
	}
}
