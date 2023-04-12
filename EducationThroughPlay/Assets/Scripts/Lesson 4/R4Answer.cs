// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class R4Answer : MonoBehaviour
{
    // Bool to check if the player got the answer correct
    bool correctAnswer1 = false;
    bool correctAnswer2 = false;
    bool correctAnswer3 = false;

    // Bool to check if all inputs are correct
    bool allCorrect = false;

    // String to hold User Input
    private string input;

    // Variable to hold Particle System
    private ParticleSystem answer4;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Particle System
        answer4 = GetComponent<ParticleSystem>();
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
    public void GetNewStartSpeed(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the main module
        var mainModule = answer4.main;

        // Change the start speed
        mainModule.startSpeed = NewValue;

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 1f)
        {
            correctAnswer1 = true;
        }
        else
        {
            correctAnswer1 = false;
        }

        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2 && correctAnswer3)
        {
            allCorrect = true;
        }
        else
        {
            allCorrect = false;
        }
    }

    // Called by User Input Field of the second panel
    public void GetNewStartSize(string tmp)
    {
        // Make input equal the user input, then convert it to a float
        input = tmp;
        float NewValue = ConvertUserInputToNumber(input);

        // Set a variable to the main module
        var mainModule = answer4.main;

        // Change the start speed
        mainModule.startSize = NewValue;

        // If the player's answer is correct (in this case 1) set the boolean
        if (NewValue == 4f)
        {
            correctAnswer2 = true;
        }
        else
        {
            correctAnswer2 = false;
        }

        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2 && correctAnswer3)
        {
            allCorrect = true;
        }
        else
        {
            allCorrect = false;
        }
    }


    // Called by white button in third panel
    public void ChangeToWhite()
    {
        // Set a variable to the main module
        var mainModule = answer4.main;

        // Change the start color
        mainModule.startColor = Color.white;

        // Set bools to reflect situation
        correctAnswer3 = false;
        allCorrect = false;
    }

    // Called by black button in third panel
    public void ChangeToBlack()
    {
        // Set a variable to the main module
        var mainModule = answer4.main;

        // Change the start color
        mainModule.startColor = Color.black;

        // Set bools to reflect situation
        correctAnswer3 = false;
        allCorrect = false;
    }

    // Called by grey button in third panel
    public void ChangeToGrey()
    {
        // Set a variable to the main module
        var mainModule = answer4.main;

        // Change the start color
        mainModule.startColor = new Color(0.5f, 0.5f, 0.5f, 1f);

        // Set bools to reflect situation
        correctAnswer3 = true;
        
        // check if all are correct and set allCorrect accordingly
        if (correctAnswer1 && correctAnswer2 && correctAnswer3)
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
        // Set a variable to the main module
        var mainModule = answer4.main;

        // Change the values back to what they were by default
        mainModule.startColor = Color.white;
        mainModule.startSpeed = 5f;
        mainModule.startSize = 1f;


        // set the booleans to accurately reflect the situation
        correctAnswer1 = false;
        correctAnswer2 = false;
        correctAnswer3 = false;
 
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