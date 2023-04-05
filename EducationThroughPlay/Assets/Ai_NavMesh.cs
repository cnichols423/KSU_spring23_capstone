// Nav mesh agent by Cohen Nichols
/* 

In this script, we first declare a public variable target of type Transform, 
which represents the location that we want the AI navmesh to move towards.

*/

using UnityEngine;
using UnityEngine.AI;


public class Ai_NavMesh : MonoBehaviour
{
   
   public Transform target; 

   private NavMeshAgent navAgent;
   
    // Start is called before the first frame update
    /*

    In the Start() method, we get a reference to the NavMeshAgent component 
    on the game object by calling GetComponent<NavMeshAgent>().

    */
    void Start(){
        navAgent = GetComponent<NavMeshAgent>(); // get the nav mesh agent component
    }



    // Update is called once per frame
    /*
    
    In the Update() method, we call navAgent.SetDestination(target.position) to set 
    the destination of the NavMeshAgent to the target position. 

    */
    void Update() {
        navAgent.SetDestination(target.position); // set the destination for the nav mesh agent
    }
}
