// Joshua Friedman
// Education Through Play
// Capstone Spring 2023
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class R8Answer : MonoBehaviour
{
    // Bool to indicate completion of room
    bool correctAnswer1 = false;

    // Variable to hold Particle System
    private ParticleSystem answer8;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Particle System
        answer8 = GetComponent<ParticleSystem>();
    }
   
    // Called by slider in second panel
    public void changeTrailWidth(float tmp)
    {
        // Get a new float and set it to tmp/10 because the slider uses whole numbers
        float NewValue = tmp/10;

        // Get the trail module
        ParticleSystem.TrailModule trailModule = answer8.trails;

        // Set the curve with the new width
        AnimationCurve curve = new AnimationCurve(new Keyframe(0, NewValue), new Keyframe(1, NewValue));
        trailModule.widthOverTrail = new ParticleSystem.MinMaxCurve(1.0f, curve);

        // update booleans
        if (NewValue == 0.1f)
        {
            correctAnswer1 = true;
        }
    }

    // Called by reset button
    public void ResetParticles()
    {
       // Get the trail module
        ParticleSystem.TrailModule trailModule = answer8.trails;

        // Set the curve with the old width
        AnimationCurve curve = new AnimationCurve(new Keyframe(0, 1.0f), new Keyframe(1, 1.0f));
        trailModule.widthOverTrail = new ParticleSystem.MinMaxCurve(1.0f, curve); 

       // update boolean
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
