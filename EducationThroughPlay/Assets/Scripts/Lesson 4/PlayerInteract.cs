// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // A float that controls the range of player interaction
        float interactRange = 3f;

        // Make a collider array and store every object that is overlapping in an array
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        // Check if any of them are able to be interacted with
        foreach (Collider collider in colliderArray)
        {
            // If the game object has the "Buttons" script attached
            if (collider.TryGetComponent(out Buttons button))
            {
                // Show the floating text
                button.ShowFloatingText();
            }
            // If the game object has the "ButtonIneraction" script attached
            if (collider.TryGetComponent(out ButtonInteraction buttonInteract))
            {
                // Show the floating text
                buttonInteract.ShowFloatingText();
            }
        }


        // When the player presses "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // For each collider in the array
            foreach (Collider collider in colliderArray)
            {
                // If the game object associated with the collider has the "Buttons" script attached
                if (collider.TryGetComponent(out Buttons button))
                {
                    // Call the interact function in the "Buttons" script
                    button.Interact();
                }

                // If the game object associated with the collider has the "ButtonIneration" script attached
                if (collider.TryGetComponent(out ButtonInteraction buttonInteract))
                {
                    // Call the interact function in the "Buttons" script
                    buttonInteract.Interact();
                }
            }
            // End of loop
        }
        // End of if statement
    }

}
