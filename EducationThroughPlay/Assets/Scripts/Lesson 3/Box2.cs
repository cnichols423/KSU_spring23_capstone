using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2 : MonoBehaviour
{

    DialogueBox db;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        db = GameObject.Find("Dialogue Box").GetComponentInChildren<DialogueBox>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player" && !db.hasDialogue())
        {
            db.sendMessage("Box Collider and rigid body with mass of " + rb.mass.ToString() + ", drag of " + rb.drag + ", and angular drag of " + rb.angularDrag + ".");
        }
    }
}
