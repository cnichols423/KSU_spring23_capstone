// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class R7Answer : MonoBehaviour
{
    // Bool to check if the player got the answer correct
    bool correctAnswer1 = false;
    bool correctAnswer2 = false;

    // Bool to check if all inputs are correct
    bool allCorrect = false;

    // String to hold User Input
    private string input;

    // Variable to hold Particle System
    private ParticleSystem answer7;

    // Floats to hold the user's inputs
    float p1 = 1f;
    float p2 = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Particle System
        answer7 = GetComponent<ParticleSystem>();
    }

    // This constructs a new AnimationCurve for the Size Over Lifetime
    private AnimationCurve getNewCurve(float p1, float p2)
    {
        // Make a new curve
        AnimationCurve newCurve = new AnimationCurve();
        
        // Add keys to the curve
        newCurve.AddKey(0f, p1);
        newCurve.AddKey(1f, p2);

        // Return the curve
        return newCurve;
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

    // Called by User Input Field of the first panel
    public void GetNewStartPoint(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the size over lifetime module
        var sizeModule = answer7.sizeOverLifetime;
        
        // set p1 to the new variable
        p1 = NewValue;

        // Get the new Size curve
        AnimationCurve newCurve = getNewCurve(p1, p2);

        // Set the size over lifetime
        sizeModule.size = new ParticleSystem.MinMaxCurve(1f, newCurve);

        // If the player's answer is correct (in this case 0) set the boolean
        if (NewValue == 0f)
        {
            correctAnswer1 = true;
        }
        else
        {
            correctAnswer1 = false;
        }

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

    // Called by User Input Field of the second panel
    public void GetNewEndPoint(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the size over lifetime module
        var sizeModule = answer7.sizeOverLifetime;

        // set p1 to the new variable
        p2 = NewValue;

        // Get the new Size curve
        AnimationCurve newCurve = getNewCurve(p1, p2);

        // Set the size over lifetime
        sizeModule.size = new ParticleSystem.MinMaxCurve(1f, newCurve);

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 1f)
        {
            correctAnswer2 = true;
        }
        else
        {
            correctAnswer2 = false;
        }

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

    // Called by reset button
    public void ResetParticles()
    {
        // Set a variable to the size over lifetime module
        var sizeModule = answer7.sizeOverLifetime;

        // Change the values back to what they were by default
        p1 = 1f;
        p2 = 1f;

        // Set the curve back
        AnimationCurve newCurve = getNewCurve(p1, p2);

        // Use the curve to reset Size over lifetime
        sizeModule.size = new ParticleSystem.MinMaxCurve(1f, newCurve);

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
