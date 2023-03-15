using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            rb.AddForce(transform.forward *  (sprintKey ? sprintSpeed : walkSpeed));
        } 

        if(backwardKey)
        {
            rb.AddForce(-transform.forward * walkSpeed);
        }

        if(rightKey)
        {
            rb.AddTorque(transform.up * turnSpeed);
        }

        if (leftKey)
        {
            rb.AddTorque(-transform.up * turnSpeed);
        }

        if(jumpKey && Mathf.Abs(rb.velocity.y) <= 0.001f) 
        {
            rb.AddForce(transform.up * jumpHeight);
        }
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

    void input() 
    {
        leftKey = Input.GetKey(KeyCode.A) ? true : false;
        rightKey = Input.GetKey(KeyCode.D) ? true : false;
        forwardKey = Input.GetKey(KeyCode.W) ? true : false;
        backwardKey = Input.GetKey(KeyCode.S) ? true : false;
        jumpKey = Input.GetKey(KeyCode.Space) ? true : false;
        sprintKey = Input.GetKey(KeyCode.LeftShift) ? true : false;
    }
}
