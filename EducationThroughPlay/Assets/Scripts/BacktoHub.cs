using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoHub : MonoBehaviour
{
    // Variable to hold the player
    [SerializeField] GameObject player;

    // Called by entering the trigger
    public void OnTriggerEnter(Collider other)
    {
        // if the other collider is the player
        if (other.gameObject == player)
        {
            // Load the Nav Hub
            SceneManager.LoadScene("Nav Hub");
        }
    }
}
