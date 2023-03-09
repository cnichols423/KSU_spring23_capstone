using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 200f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;
        //var tmp = Player.anim.speed;

    void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (Input.GetKey ("w")) {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetInteger("AnimationPar", 1);
                }
			}  
            else {
				anim.SetInteger ("AnimationPar", 0);
			}

            if (Input.GetKey(KeyCode.LeftShift))
            {
            speed = 400f;
            anim.SetInteger("AnimationPar", 2);
        }
            else
            {
            speed = 200f;
        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
        else
        {
            
        }

        if (controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
}
