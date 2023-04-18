using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    MeshRenderer mr;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        c = mr.material.color;
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
