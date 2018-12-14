using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;	// Detection range for player

    private float randMax = 10f;

    private bool atTarget;
    private float stoppingRef = 2f;

    private bool navFound;

    private Vector3 wanderTarget;
    private float wanderDistance;
    private float wanderTime = 0f;
    public float wanderTimeLimit = 5;

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
        wanderDistance = Vector3.Distance(wanderTarget, transform.position);
        //print(wanderTarget);
        //print(wanderDistance);
        stoppingRef = agent.stoppingDistance;

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
            wanderTime += Time.deltaTime;
            if (wanderDistance <= agent.stoppingDistance || wanderTime >= wanderTimeLimit)
            {
                navFound = false;
                wanderTarget = RandomNavSphere(transform.position, randMax, 1);
                //print("Target Destination: " + agent.destination);
                //Debug.Log("Wander Distance in if: " + wanderDistance);

                agent.SetDestination(wanderTarget);
                wanderTime = 0;
            }
            //Debug.Log("Wander Distance out if: " + wanderDistance);
        }
	}

	// Rotate to face the target
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

    

    private Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        if (!navFound)
        {
            Vector3 randomDirection = Random.insideUnitSphere * distance;
            Debug.Log("Before: " + randomDirection);
            randomDirection += origin;
            Debug.Log("After: " + randomDirection);
            NavMeshHit navHit;
            //print(randomDirection);


            navFound = NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
            print(navFound);

            print("NAVHITPOSTION" + navHit.position);
            return navHit.position;
        }
        return transform.position;
        
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stoppingRef);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(agent.destination, 1);

    }
}
