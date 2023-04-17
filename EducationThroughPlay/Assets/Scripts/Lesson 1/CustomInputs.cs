using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputs : MonoBehaviour
{
    // Ill need R For Reset I For Increase l for Decrease
    //Astronaut Player Class by Jason Abounader
    //Physics based movement 

    //public float walkSpeed, sprintSpeed, turnSpeed, jumpHeight;

    //private Rigidbody rb;
    //private Animator anim;

    //private bool leftKey, rightKey, forwardKey, backwardKey, jumpKey, sprintKey;

    private bool hKeyPress;
    private float Speed = 0.5f;
    public GameObject roomTwoNpc;
    public GameObject roomThreeNpc;
    public NPCControllers mainController;
    public NPCControllers mainThreeController;
    private float nextActionTime = 0.0f;
    public float period = 15f;
    // Start is called before the first frame update
    void Start()
    {
        mainController = roomTwoNpc.GetComponent<NPCControllers>();
        mainThreeController = roomThreeNpc.GetComponent<NPCControllers>();
    }

    private void Update()
    {
        input();
        if(Input.GetKeyDown(KeyCode.G)){
            mainController.StartRoomTwoLeft();
        }
        if(Input.GetKeyUp(KeyCode.G)){
            mainController.StartRoomTwoRight();
        }
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
 
        float moveVertical = Input.GetAxisRaw("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        //movement = movement * Speed * Time.deltaTime;

    }

    void FixedUpdate()
    {
        if(hKeyPress){
            //MoveRoomThreeLeft
            nextActionTime += period;
            mainThreeController.MoveRoomThreeLeft();
            mainThreeController.MoveRoomThreeRight(nextActionTime);
        }
    }
    void input() 
    {
        hKeyPress = Input.GetKey(KeyCode.H) ? true : false;
    }

}
