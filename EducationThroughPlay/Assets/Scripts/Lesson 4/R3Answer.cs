// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class R3Answer : MonoBehaviour
{
    // Bool to check if the player got the answer correct
    bool correctAnswer1 = false;
    bool correctAnswer2 = true;
    bool correctAnswer3 = true;
    bool correctAnswer4 = false;

    // Bool to check if all inputs are correct
    bool allCorrect = false;

    // String to hold User Input
    private string input;

    // Variable to hold Particle System
    private ParticleSystem answer3;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Particle System
        answer3 = GetComponent<ParticleSystem>();
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
    public void GetNewXVelocity(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the velocity module
        ParticleSystem.VelocityOverLifetimeModule velocityModule = answer3.velocityOverLifetime;

        // Change the Linear Velocity Over time on the x-axis
        velocityModule.x = new ParticleSystem.MinMaxCurve(NewValue);

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 3f)
        {
            correctAnswer1 = true;
        }
        else
        {
            correctAnswer1 = false;
        }

        // check if all are correct and set allCorrect accordingly
        if(correctAnswer1 && correctAnswer2 && correctAnswer3 && correctAnswer4)
        {
            allCorrect = true;
        }
        else
        {
            allCorrect = false;
        }
    }

    // Called by User Input Field of the second panel
    public void GetNewYVelocity(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the velocity module
        ParticleSystem.VelocityOverLifetimeModule velocityModule = answer3.velocityOverLifetime;

        // Change the Linear Velocity Over time on the y-axis
        velocityModule.y = new ParticleSystem.MinMaxCurve(NewValue);

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 0f)
        {
            correctAnswer2 = true;
        }
        else
        {
            correctAnswer2 = false;
        }

        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2 && correctAnswer3 && correctAnswer4)
        {
            allCorrect = true;
        }
        else
        {
            allCorrect = false;
        }
    }

    // Called by User Input Field of the third panel
    public void GetNewZVelocity(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the velocity module
        ParticleSystem.VelocityOverLifetimeModule velocityModule = answer3.velocityOverLifetime;

        // Change the Linear Velocity Over time on the z-axis
        velocityModule.z = new ParticleSystem.MinMaxCurve(NewValue);

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 0f)
        {
            correctAnswer3 = true;
        }
        else
        {
            correctAnswer3 = false;
        }

        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2 && correctAnswer3 && correctAnswer4)
        {
            allCorrect = true;
        }
        else
        {
            allCorrect = false;
        }
    }

    // Called by User Input Field of the Fourth panel
    public void GetNewSpeedModifier(float tmp)
    {
        // Make input equal the user input, divide it by 10 as slider gives whole number values
        float NewValue = tmp/10;
        
        // Set a variable to the velocity module
        ParticleSystem.VelocityOverLifetimeModule velocityModule = answer3.velocityOverLifetime;

        // Change the Linear Velocity Over time on the x-axis
        velocityModule.speedModifier = new ParticleSystem.MinMaxCurve(NewValue);

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 0.2f)
        {
            correctAnswer4 = true;
        }
        else
        {
            correctAnswer4 = false;
        }

        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2 && correctAnswer3 && correctAnswer4)
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
        // Set a variable to the velocity module
        ParticleSystem.VelocityOverLifetimeModule velocityModule = answer3.velocityOverLifetime;

        // Reset all the values to what they are set to by default
        velocityModule.x = new ParticleSystem.MinMaxCurve(0f);
        velocityModule.y = new ParticleSystem.MinMaxCurve(0f);
        velocityModule.z = new ParticleSystem.MinMaxCurve(0f);
        velocityModule.speedModifier = new ParticleSystem.MinMaxCurve(1f);

        // set the booleans to accurately reflect the situation
        correctAnswer1 = false;
        correctAnswer2 = true;
        correctAnswer3 = true;
        correctAnswer4 = false;
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
