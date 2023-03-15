using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    private Animator anim;
    private CharacterController controller;
    private Rigidbody rb;


    public float speed = 20f;
    public float turnSpeed = 400.0f;
    
    public float gravity = 20.0f;


    public float jump = 5.0f;
    bool isJumping;
    float jumpTemp;

    private Vector3 moveDirection = Vector3.zero;
    //var tmp = Player.anim.speed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(jumpTemp);
        movement();

        // Implementation of Jump
        //on the ground and space is pressed
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            anim.SetInteger("AnimationPar", 3);
            isJumping = true;
            jumpTemp = 0.0f;

        }
        if (!Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            //anim.SetInteger("Jump Start", 0);
        }

        if (controller.isGrounded && !Input.GetKey("w") && !Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("AnimationPar", 0);
        }

        if(isJumping) {
            jumpTemp = Mathf.Lerp(jumpTemp, jump, Time.deltaTime);
            controller.Move(transform.up * jumpTemp);

            if(jumpTemp >= .1) {
                isJumping = false; 
                jumpTemp = 0.0f;
            }
        }
    }

    void movement() {

        // Implementation of walk
        if (Input.GetKeyDown("w"))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetInteger("AnimationPar", 1);
            }
        }

        // Implementation of sprint
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            speed = 40f;
            anim.SetInteger("AnimationPar", 2);
        }
        else
        {
            speed = 20f;
        }

        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }
        
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}
