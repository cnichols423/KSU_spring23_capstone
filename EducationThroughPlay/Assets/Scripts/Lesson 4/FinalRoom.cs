using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{
    // Serialized fields to hold each particle effect
    [SerializeField] R1Answer r1;
    [SerializeField] R2Answer r2;
    [SerializeField] R3Answer r3;
    [SerializeField] R4Answer r4;
    [SerializeField] R5Answer r5;
    [SerializeField] R6Answer r6;
    [SerializeField] R7Answer r7;
    [SerializeField] R8Answer r8;
    [SerializeField] R9Answer r9;

    // Serialzed field to hold the glass cylinder blocking the goal
    [SerializeField] GameObject cylinder; 

    // Called when another collider enters this collider
    private void OnTriggerEnter(Collider other){
        // Check all rooms for completion
        if(r1.CompletionCheck() && r2.CompletionCheck() && r3.CompletionCheck() && r4.CompletionCheck() && r5.CompletionCheck()
        && r6.CompletionCheck() && r7.CompletionCheck() && r8.CompletionCheck() && r9.CompletionCheck()){
            // Get the collider and the rigid body for the cylinder
            Collider coll = cylinder.GetComponent<Collider>();
            // Disable the collider to drop the cylinder and make the goal reachable
            coll.enabled = false;
        }
    }
}
