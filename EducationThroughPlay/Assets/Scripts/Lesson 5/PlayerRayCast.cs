using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    // Variable to store the number of buttons hit
    float buttonsHit = 0f;
    
    // Serialzed field to hold the glass cylinder blocking the goal
    [SerializeField] GameObject cylinder;

    // Create a variable for the lineRenderer
    private LineRenderer lineRenderer;

    // create a variable to hold a hit button
    private ButtonRayCast hitButton;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Line Renderer
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Coroutine to delay after line is drawn to keep it visible longer
    IEnumerator KeepLineOnScreen()
    {
        // Wait
        yield return new WaitForSeconds(2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Cast a ray cast
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Check that what was hit was a button
            if (hit.collider.GetComponent<ButtonRayCast>() != null){
                // If it was enable the line renderer
                lineRenderer.enabled = true;
                // Make the line
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);

                // Check if the hit button has already been hit
                hitButton = hit.collider.GetComponent<ButtonRayCast>();
                
                // If the button hasn't been hit
                if(hitButton.alreadyHit == false)
                {
                    // Switch its color
                    hitButton.SwitchColor();
                    // Add one to the number of buttons hit
                    buttonsHit = buttonsHit + 1f;
                }
                // Call the coroutine to wait to keep the line on screen
                StartCoroutine(KeepLineOnScreen());
            }
            else
            {
                // Stops a line from being drawn when item hit is not button
                lineRenderer.enabled = false;
            }
        }
        else
        {
            // Stops a line from being drawn when nothing is hit
            lineRenderer.enabled = false;
        }

        // If all 6 buttons have been hit drop the cylinder
        if (buttonsHit == 6f)
        {
            // Get the collider and the rigid body for the cylinder
            Collider coll = cylinder.GetComponent<Collider>();
            // Disable the collider to drop the cylinder and make the goal reachable
            coll.enabled = false;
        }
    }
}
