// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class R1Answer : MonoBehaviour
{
    // String to hold User Input
    private string input;

    // Variable to hold Particle System
    private ParticleSystem answer1;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Particle System
        answer1 = GetComponent<ParticleSystem>();
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
        var main = answer1.main;

        // Change the Start Life Time
        main.startLifetime = NewValue;
    }

    // Called by reset button
    public void ResetParticles()
    {
        // Set a variable to the main
        var main = answer1.main;

        // Change the Start Time back to 1 which is it's starting value
        main.startLifetime = 1f;
    }
}
