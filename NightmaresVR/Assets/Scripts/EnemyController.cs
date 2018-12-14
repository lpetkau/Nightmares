using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;	// Detection range for player

    private float randMax = 40f;

    private bool atTarget;

    private Vector3 wanderTarget;

	Transform target;	// Reference to the player
	NavMeshAgent agent; // Reference to the NavMeshAgent
	

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent = GetComponent<NavMeshAgent>();

        wanderTarget = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		// Distance to the target
		float distance = Vector3.Distance(target.position, transform.position);

		// If inside the lookRadius
		if (distance <= lookRadius)
		{
			// Move towards the target
			agent.SetDestination(target.position);
            FaceTarget();

            // If within attacking distance
            if (distance <= agent.stoppingDistance)
			{
				
			}
		}
        //Not inside lookRadius
        else
        {
            print(agent.destination);
            agent.SetDestination(RandomNavSphere(transform.position, randMax, 0));
        }
	}

	// Rotate to face the target
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

    

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
        
	}
}
