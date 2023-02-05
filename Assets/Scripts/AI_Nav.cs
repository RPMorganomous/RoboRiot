using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Nav : MonoBehaviour
{
    // move the AI to a Waypoint
    public List<Transform> waypoints;
    private NavMeshAgent agent;
    private int currentWaypoint = 0;

// Start is called before the first frame update
    void Start()
    {
        // Assign the NavMeshAgent component to the agent variable
        agent = GetComponent<NavMeshAgent>();
        // Enable auto braking and the NavMeshAgent component
        agent.autoBraking = true;
        agent.enabled = true;
        // Set the initial destination to the first waypoint in the list
        agent.destination = waypoints[currentWaypoint].position;
    }

// Update is called once per frame
    void Update()
    {
        // Check if the distance to the current waypoint is within a certain range
        if (agent.remainingDistance < 0.5f)
        {
            // If so, set the next waypoint as the destination
            
            // if currentWaypoint = last waypoint then destroy the object
            if (currentWaypoint == waypoints.Count - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
                agent.SetDestination(waypoints[currentWaypoint].position);
            }

        }

        // Check if the NavMeshAgent is on the nav mesh, not stopped or stained, has a path, and is not pending
        if (agent.isOnNavMesh && !agent.isStopped && !agent.isPathStale && agent.hasPath && !agent.pathPending &&
            agent.remainingDistance < 0.5f)
        {
            // If so, set the next waypoint as the destination
            currentWaypoint = (int)Mathf.Repeat(currentWaypoint + 1, waypoints.Count);
            agent.destination = waypoints[currentWaypoint].position;
            // Alternatively, select the next waypoint randomly:
            // agent.destination = waypoints[Random.Range(0, waypoints.Count)].position;
        }
        agent.destination = waypoints[currentWaypoint].position;
    }
}
