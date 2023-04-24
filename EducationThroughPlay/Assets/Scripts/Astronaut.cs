using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Astronaut : MonoBehaviour
{
    //Astronaut Player Class by Jason Abounader
    //Physics based movement 

    public float walkSpeed, sprintSpeed, turnSpeed, jumpHeight;

    private Rigidbody rb;
    private Animator anim;

    private bool leftKey, rightKey, forwardKey, backwardKey, jumpKey, sprintKey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = transform.InverseTransformPoint(transform.Find("Player").position);
        anim = gameObject.GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        input();
        animationControl();
    }


    void FixedUpdate()
    {
        if(forwardKey)
        {
            //rb.AddForce(transform.forward *  (sprintKey ? sprintSpeed : walkSpeed));
            Vector3 vel = transform.forward * (sprintKey ? sprintSpeed : walkSpeed);
            vel.y = rb.velocity.y;
            rb.velocity = vel;
           
        } 

        if(backwardKey)
        {
            //rb.AddForce(-transform.forward * walkSpeed);
            //rb.velocity = transform.forward * walkSpeed * -1;
            Vector3 vel = transform.forward * walkSpeed * -1;
            vel.y = rb.velocity.y;
            rb.velocity = vel;
        }

        if(!forwardKey && !backwardKey)
        {
            Vector3 temp = rb.velocity;
            temp.x = 0;
            temp.z = 0;
            rb.velocity = temp;
        }


        if(rightKey)
        {
            //rb.AddTorque(transform.up * turnSpeed);
            //rb.angularVelocity = transform.up * turnSpeed;
            transform.Rotate(transform.up * turnSpeed);


        }

        if (leftKey)
        {
            //rb.AddTorque(-transform.up * turnSpeed);
            //rb.angularVelocity = transform.up * -turnSpeed;
            transform.Rotate(transform.up * -turnSpeed);

        }

        if(!rightKey && !leftKey)
        {
            rb.angularVelocity = Vector3.zero;
        }

        
    }

    void animationControl()
    {
        
    }

    void input() 
    {
        leftKey = Input.GetKey(KeyCode.A) ? true : false;
        rightKey = Input.GetKey(KeyCode.D) ? true : false;
        forwardKey = Input.GetKey(KeyCode.W) ? true : false;
        backwardKey = Input.GetKey(KeyCode.S) ? true : false;
        jumpKey = Input.GetKey(KeyCode.Space) ? true : false;
        sprintKey = Input.GetKey(KeyCode.LeftShift) ? true : false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (jumpKey && Mathf.Abs(rb.velocity.y) <= .50f)
        {
            rb.AddForce(transform.up * jumpHeight);
        }

        if (Mathf.Abs(rb.velocity.x) >= 0.1f || Mathf.Abs(rb.velocity.x) >= 0.1f)
        {
            anim.SetInteger("AnimationPar", 1);

        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        /*
        if (Mathf.Abs(rb.velocity.y) >= 1.0f)
        {
            //anim.SetInteger("AnimationPar", 3);

        }
        */
        anim.SetInteger("AnimationPar", 3);
    }


}
