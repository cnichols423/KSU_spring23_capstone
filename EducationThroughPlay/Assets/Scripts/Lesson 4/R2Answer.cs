// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class R2Answer : MonoBehaviour
{
    // Bool to check if the player got the answer correct
    bool correctAnswer1 = false;

    // String to hold User Input
    private string input;

    // Variable to hold Particle System
    private ParticleSystem answer2;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Particle System
        answer2 = GetComponent<ParticleSystem>();
    }

    // This converts a user's input to a float
    private float ConvertUserInputToNumber(string input)
    {
        // Create a string out of the numbers, periods and hyphens in the text
        string cleanedInput = Regex.Replace(input, "[^0-9.-]", "");

        // Parse the cleanedInput into a float called result
        float.TryParse(cleanedInput, out float result);

        // If parsing was successful return the float, else the value will be 0 which is a valid answer
        return result;
    }

    // Called by User Input Field
    public void ReadStringInput(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the main
        var main = answer2.main;

        // Change the Gravity Modifier Multiplier
        main.gravityModifierMultiplier = NewValue;

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 3f)
        {
            correctAnswer1 = true;
        }
        else
        {
            correctAnswer1 = false;
        }
    }

    // Called by reset button
    public void ResetParticles()
    {
        // Set a variable to the main
        var main = answer2.main;

        // Change the Gravity Modifier back to 0 which is it's starting value
        main.gravityModifierMultiplier = 0f;

        // set the boolean to false as the answer is definitely not correct
        correctAnswer1 = false;
    }

    // Called by button to see if it should change color, and final cylinder to see if it should drop
    public bool CompletionCheck()
    {
        // This is an accessor for the boolean value
        if (correctAnswer1 == true)
        {
            return true;
        }
        else { return false; }
    }

}