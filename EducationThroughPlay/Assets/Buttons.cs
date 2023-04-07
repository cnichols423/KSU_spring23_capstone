// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Initialize a variable to hold the UI element to display (this is set in the Unity Editor on a per item basis)
    [SerializeField] private GameObject containerGameObject;

    // Function to show the UI element
    private void Show()
    {
        // Set the UI element to active
        containerGameObject.SetActive(true);
    }

    // Function that gets called by "PlayerInteract"
    public void Interact()
    {
        // When the User interacts with the object show the associated UI element
        Show();
    }
}
