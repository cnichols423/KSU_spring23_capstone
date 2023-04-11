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
    // flag to see if moving is allowed yet
    public bool isMoving;
    
    
    
    
    // Start is called before the first frame update
    /*  

    In the Start() method, we get a reference to the NavMeshAgent component 
    on the game object by calling GetComponent<NavMeshAgent>().

    */
    private void Start(){
        // get the nav mesh agent component
        navAgent = GetComponent<NavMeshAgent>(); 
        //currentTargetIndex = 0;
        isMoving = false;
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
        if (isMoving && navAgent.remainingDistance <= navAgent.stoppingDistance){
            currentTargetIndex++;
            if (currentTargetIndex >= navAgent.path.corners.Length){
                isMoving = false;
                //currentTargetIndex = 0;
                navAgent.ResetPath();
            }
            else{
                navAgent.SetDestination(navAgent.path.corners[currentTargetIndex]);
            }
        }
    }

    // sets targets for array on script start
    public void SetTargets(Transform[] targets){
        navAgent.isStopped = true;
        navAgent.ResetPath();
        currentTargetIndex = 0;
        isMoving = false;

        if (targets.Length > 0){
            navAgent.SetDestination(targets[currentTargetIndex].position);
            currentTargetIndex++;
            isMoving = true;
        }
    }

   

}      // end of script


