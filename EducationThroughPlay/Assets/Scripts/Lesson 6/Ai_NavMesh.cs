// Nav mesh agent by Cohen Nichols
/* 

In this script, we first declare a public variable target of type Transform, 
which represents the location that we want the AI navmesh to move towards.

*/

using UnityEngine;
using UnityEngine.AI;


public class Ai_NavMesh : MonoBehaviour
{
    // an array of targets for the ai agent to move to 
    public Transform[] targets;      
    // the ai agent in the game
    private NavMeshAgent navAgent; 
    // the current index for the target array
    private int currentTargetIndex; 

    
    // Start is called before the first frame update
    /*  

    In the Start() method, we get a reference to the NavMeshAgent component 
    on the game object by calling GetComponent<NavMeshAgent>().

    */
    private void Start(){
        // get the nav mesh agent component
        navAgent = GetComponent<NavMeshAgent>(); 
        currentTargetIndex = 0;
        
    }



    // Update is called once per frame
    /*
    
    In the Update() method, we check to see if the agent has reached the end position.
    if not we check the remaining distance to next target and the distance the agent needs to stop at
    if the remainging distance is <= to stop distance
    ++target index and check to see if we are at the last index in array 
    if not set next destination and keep moving.

    */
  
    // Update is called once per frame
   void Update(){
        
    if (targets.Length == 0) return;

    if (navAgent.remainingDistance <= navAgent.stoppingDistance)
    {
        // Move to the next target
        currentTargetIndex++;
        if (currentTargetIndex >= targets.Length)
        {
            // Reached the end position, stop moving
            navAgent.isStopped = true;
            return;
        }

        // Set the next target
        navAgent.SetDestination(targets[currentTargetIndex].position);
    }
        
    }

   

   

}      // end of script


