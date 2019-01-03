using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health;

    private bool damageDone = false;
    public int damageMultiplyer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        
        
            TakeDamage(collision.relativeVelocity.magnitude * damageMultiplyer);
            damageDone = true;
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            damageDone = false;
        }
    }

    private void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        print(damageToTake);
    }
}
