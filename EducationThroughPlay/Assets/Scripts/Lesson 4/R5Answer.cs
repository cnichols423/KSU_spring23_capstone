// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class R5Answer : MonoBehaviour
{
    // Bool to check if the player got the answer correct
    bool correctAnswer1 = false;
    bool correctAnswer2 = false;

    // Bool to check if all inputs are correct
    bool allCorrect = false;

    // Variable to hold Particle System
    private ParticleSystem answer5;

    // variables to hold colors when creating gradient
    Color selectedColor1 = Color.blue;
    Color selectedColor2 = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Particle System
        answer5 = GetComponent<ParticleSystem>();
    }

    // Creates a gradient
    private Gradient SetGradient(Gradient toChange)
    {
        toChange.SetKeys(new GradientColorKey[] { new GradientColorKey(selectedColor1, 0.0f), new GradientColorKey(selectedColor2, 1.0f) },
                         new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        return toChange;
    } 
   
    // Called by red button in first panel
    public void ChangeStartRed()
    {
        // Set a variable to the main module and then set start color
        var colorOverLifetime = answer5.colorOverLifetime;
        selectedColor1 = Color.red;

        // Make a new Gradient with the selection
        Gradient gradient = new Gradient();

        // Call the function to set the keys
        gradient = SetGradient(gradient);

        // Switch to the new gradient
        colorOverLifetime.color = gradient;

        // Set bools to reflect situation
        correctAnswer1 = false;
        allCorrect = false;
    }

    // Called by blue button in first panel
    public void ChangeStartBlue()
    {
        // Set a variable to the main module and then set start color
        var colorOverLifetime = answer5.colorOverLifetime;
        selectedColor1 = Color.blue;

        // Make a new Gradient with the selection
        Gradient gradient = new Gradient();

        // Call the function to set the keys
        gradient = SetGradient(gradient);

        // Switch to the new gradient
        colorOverLifetime.color = gradient;

        // Set bools to reflect situation
        correctAnswer1 = false;
        allCorrect = false;
    }

    // Called by yellow button in first panel
    public void ChangeStartYellow()
    {
        // Set a variable to the main module and then set start color
        var colorOverLifetime = answer5.colorOverLifetime;
        selectedColor1 = Color.yellow;

        // Make a new Gradient with the selection
        Gradient gradient = new Gradient();

        // Call the function to set the keys
        gradient = SetGradient(gradient);

        // Switch to the new gradient
        colorOverLifetime.color = gradient;

        // Set bools to reflect situation
        correctAnswer1 = true;

        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2)
        {
            allCorrect = true;
        }
        else
        {
            allCorrect = false;
        }
    }

    // Called by red button in second panel
    public void ChangeEndRed()
    {
        // Set a variable to the main module and then set end color
        var colorOverLifetime = answer5.colorOverLifetime;
        selectedColor2 = Color.red;

        // Make a new Gradient with the selection
        Gradient gradient = new Gradient();

        // Call the function to set the keys
        gradient = SetGradient(gradient);

        // Switch to the new gradient
        colorOverLifetime.color = gradient;

        // Set bools to reflect situation
        correctAnswer2 = true;

        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2)
        {
            allCorrect = true;
        }
        else
        {
            allCorrect = false;
        }
    }

    // Called by blue button in second panel
    public void ChangeEndBlue()
    {
        // Set a variable to the main module and then set end color
        var colorOverLifetime = answer5.colorOverLifetime;
        selectedColor2 = Color.blue;

        // Make a new Gradient with the selection
        Gradient gradient = new Gradient();

        // Call the function to set the keys
        gradient = SetGradient(gradient);

        // Switch to the new gradient
        colorOverLifetime.color = gradient;

        // Set bools to reflect situation
        correctAnswer2 = false;
        allCorrect = false;
    }

    // Called by yellow button in first panel
    public void ChangeEndYellow()
    {
        // Set a variable to the main module and then set end color
        var colorOverLifetime = answer5.colorOverLifetime;
        selectedColor2 = Color.yellow;

        // Make a new Gradient with the selection
        Gradient gradient = new Gradient();

        // Call the function to set the keys
        gradient = SetGradient(gradient);

        // Switch to the new gradient
        colorOverLifetime.color = gradient;

        // Set bools to reflect situation
        correctAnswer2 = false;
        allCorrect = false;
    }

    // Called by reset button
    public void ResetParticles()
    {
        // Set a variable to the main module and one to the start color
        var mainModule = answer5.main;
        var startColor = mainModule.startColor;

        // Change the values back to what they were by default
        startColor.colorMin = Color.blue;
        startColor.colorMax = Color.red;

        // set the booleans to accurately reflect the situation
        correctAnswer1 = false;
        correctAnswer2 = false;

        allCorrect = false;
    }

    // Called by button to see if it should change color, and final cylinder to see if it should drop
    public bool CompletionCheck()
    {
        // This is an accessor for the boolean value
        if (allCorrect == true)
        {
            return true;
        }
        else { return false; }
    }

}
