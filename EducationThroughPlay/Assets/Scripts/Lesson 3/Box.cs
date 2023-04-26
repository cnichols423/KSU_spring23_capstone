using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    MeshRenderer mr;
    Color c;

    DialogueBox db;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        c = mr.material.color;

        db = GameObject.Find("Dialogue Box").GetComponentInChildren<DialogueBox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            mr.material.color = Color.yellow;
            
            if(!db.hasDialogue())
            {
                db.sendMessage("A box collider with a trigger. No physics...");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            mr.material.color = c;
        }
    }
}
