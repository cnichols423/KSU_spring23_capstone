using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovements : MonoBehaviour
{
    // Ill need R For Reset I For Increase l for Decrease
    //Astronaut Player Class by Jason Abounader
    //Physics based movement 

    public float walkSpeed, sprintSpeed, turnSpeed, jumpHeight;

    private Rigidbody rb;
    private Animator anim;

    private bool leftKey, rightKey, forwardKey, backwardKey, jumpKey, sprintKey;

    public Transform startPoint;
    public Vector3 originalPos;
    private Quaternion rot;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = transform.InverseTransformPoint(transform.Find("Player").position);
        anim = gameObject.GetComponentInChildren<Animator>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        rot = new Quaternion(gameObject.transform.rotation.w,gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
    }

    private void Update()
    {
        animationControl();
    }


    void FixedUpdate()
    {
    }

    void animationControl()
    {
        if(Mathf.Abs(rb.velocity.y) >= 0.05f) 
        {
            anim.SetInteger("AnimationPar", 3);

        }else if(Mathf.Abs(rb.velocity.x) >= 0.1f || Mathf.Abs(rb.velocity.x) >= 0.1f)
        {
            anim.SetInteger("AnimationPar", 1);

        } else
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }

    public void Reset(){
        gameObject.transform.position = originalPos;
    }
    public void MoveForwardForce(float speed){
        rb.AddForce(transform.forward *  (speed));
    }
    public void simulateInput(){
        rb.AddForce(transform.forward *  (walkSpeed));
    }
    public void MoveForward(){
        rb.AddForce(transform.forward *  (sprintSpeed));
        rb.AddForce(transform.forward *  (sprintSpeed));
        rb.AddForce(transform.forward *  (sprintSpeed));
        rb.AddForce(transform.forward *  (sprintSpeed));
        rb.AddForce(transform.forward *  (sprintSpeed));
        rb.AddForce(transform.forward *  (sprintSpeed));
        rb.AddForce(transform.forward *  (sprintSpeed));
        //rb.AddForce(transform.forward *  (sprintSpeed));
        //rb.AddForce(transform.forward *  (sprintSpeed));
    }
    public void MoveBackward(){
        rb.AddForce(-transform.forward * walkSpeed);
        rb.AddForce(-transform.forward * walkSpeed);
        rb.AddForce(-transform.forward * walkSpeed);
        rb.AddForce(-transform.forward * walkSpeed);
        //rb.AddForce(-transform.forward * walkSpeed);
        //rb.AddForce(-transform.forward * walkSpeed);
        //rb.AddForce(-transform.forward * walkSpeed);
        //rb.AddForce(-transform.forward * walkSpeed);
        //rb.AddForce(-transform.forward * walkSpeed);
    }
    public void Jump(){
        rb.AddForce(transform.up * jumpHeight);
    }
    public void Destroy(){}

}
