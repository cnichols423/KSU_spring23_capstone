/* Nav mesh agent by Cohen Nichols

In this script, we first declare a public game object for the player model
then use the unity ai to create the nav mesh agent object we want to make move


*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AiFollowPlayer : MonoBehaviour
{
    public GameObject playerModel;
    private NavMeshAgent aiAgent;
    
    // Start is called before the first frame update
    public void Start()
    {
        aiAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        aiAgent.destination = playerModel.transform.position;
    }
}
