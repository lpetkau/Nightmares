using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Transform target;

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform.Translate(target.position * Time.deltaTime * speed);
	}
}
