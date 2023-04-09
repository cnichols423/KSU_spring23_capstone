// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Initialize a variable to hold the UI popup window to display upon interaction
    [SerializeField] private GameObject containerGameObject;

    // Initialize a variable to hold the message that a player is able to interact
    [SerializeField] private GameObject floattext;

    // Set 2 optional serizalized field to reset the particle effects
    [SerializeField] private GameObject hint = null;
    [SerializeField] private GameObject answer = null;

    // Function to show the UI popup window
    private void ShowPopup()
    {
        // Set the UI element to active
        containerGameObject.SetActive(true);

        // Check to see if we have a hint and answer item
        if (hint != null && answer != null)
        {
            // Get the particle systems from them
            ParticleSystem hintSystem = hint.GetComponent<ParticleSystem>();
            ParticleSystem answerSystem = answer.GetComponent<ParticleSystem>();
            
            // Then Stop them and clear them during the pop up
            hintSystem.Stop();
            answerSystem.Stop();
            hintSystem.Clear();
            answerSystem.Clear();
        }
    }

    // Function to show the floating text letting player know they can interact
    public void ShowFloatingText()
    {
        floattext.SetActive(true);
    }

    // Function to hide the floating text letting the player know they cannot interact
    public void DestroyFloatingText()
    {
        floattext.SetActive(false);
    }

    // Function that gets called by "PlayerInteract"
    public void Interact()
    {
        // When the User interacts with the object show the associated UI element
        ShowPopup();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 
        // The float that controls the range of player interaction
        float interactRange = 5f;

        // Boolean to see if player is in range
        bool playerCheck = false;

        // Make a collider array and store every object that is overlapping in an array
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        // Check each collider in the array
        foreach (Collider collider in colliderArray)
        {
            // If one of them is the player
            if (collider.TryGetComponent(out PlayerInteract player))
            {
                // Set playerCheck to true
                playerCheck = true;
            }
        }

        // Check if the playerCheck remained false
        if (playerCheck == false)
        {
            // If it did destroy the floating text
            DestroyFloatingText();
        }

        // Check if we have a hint and answer object
        if (hint != null && answer != null)
        {
            // Get the particle systems from them
            ParticleSystem hintSystem = hint.GetComponent<ParticleSystem>();
            ParticleSystem answerSystem = answer.GetComponent<ParticleSystem>();

            // Check if the UI window is active and if the particle effects are stopped
            if (!containerGameObject.activeSelf && hintSystem.isStopped && answerSystem.isStopped)
            {
                // Play them
                hintSystem.Play();
                answerSystem.Play();
            }
           
        }
    }


}
