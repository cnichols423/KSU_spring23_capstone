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
    void Start(){
        // get the nav mesh agent component
        navAgent = GetComponent<NavMeshAgent>(); 
        // set the current index of target array to 0 on start
        currentTargetIndex = 0; 
    }



    // Update is called once per frame
    /*
    
    In the Update() method, we call navAgent.SetDestination(target.position) to set 
    the destination of the NavMeshAgent to the target position. 

    */
    void Update() {
        if(navAgent.remainingDistance <= navAgent.stoppingDistance){
            // if ai has reached the target move to next one
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
            navAgent.SetDestination(targets[currentTargetIndex].position);
        }
        
        else{
            // else keep moving towards current target
            navAgent.SetDestination(targets[currentTargetIndex].position); 
        }
    }
}
