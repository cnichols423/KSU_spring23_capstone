using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    private Animator anim;
    private CharacterController controller;

    public float speed = 20f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    //var tmp = Player.anim.speed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
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

        // Implementation of Jump
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            anim.SetInteger("AnimationPar", 3);
            transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
        }
        if (!Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            //anim.SetInteger("Jump Start", 0);
        }

        if (controller.isGrounded && !Input.GetKey("w") && !Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }
}
