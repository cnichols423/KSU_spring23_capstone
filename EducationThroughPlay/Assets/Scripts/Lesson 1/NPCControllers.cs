using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControllers : MonoBehaviour
{
    public GameObject[] currentNPCs;
    private float nextActionTime = 0.0f;
    public float period = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            ResetNpcs();
        }
    }

    private void ResetNpcs(){
        currentNPCs[0].GetComponent<NPCMovements>().Reset();
        currentNPCs[1].GetComponent<NPCMovements>().Reset();
    }

    public void StartRoomTwoLeft(){
        currentNPCs[0].GetComponent<NPCMovements>().MoveForward();
    }
    public void StartRoomTwoRight(){
        currentNPCs[1].GetComponent<NPCMovements>().MoveForward();
    }
    public void MoveRoomThreeLeft(){
        currentNPCs[0].GetComponent<NPCMovements>().simulateInput();
    }
    public void MoveRoomThreeRight(float speed){
        currentNPCs[1].GetComponent<NPCMovements>().MoveForwardForce(speed);
    }
}
