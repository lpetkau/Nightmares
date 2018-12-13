using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGlow : MonoBehaviour {

    public float glowDecreaser;
    public float rangeIncreaser;

    private Vector3 target;
    private GameObject player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
        //GetComponent<Light>().intensity = (Vector3.Distance(target, this.transform.position) / glowDecreaser);
        GetComponent<Light>().range = (Vector3.Distance(target, this.transform.position) * rangeIncreaser);
    }
}
