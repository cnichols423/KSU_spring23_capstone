using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRayCast : MonoBehaviour
{
    // Boolean to control count going up in PlayerRayCast
    public bool alreadyHit = false;

    // Variables to hold material to switch to when hit
    private MeshRenderer meshRenderer;
    [SerializeField] Material greenButton; 

    // Start is called before the first frame update
    void Start()
    {
        // Get the mesh renderer
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Called in the PlayerRayCast script, is an accessor to bool
    public bool checkAlreadyHit()
    {
        if (alreadyHit == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Called in the PlayerRayCast script, switches button color
    public void SwitchColor()
    {
        // Switch the material to the green button
        meshRenderer.material = greenButton;

        // set the boolean to show that this button has already been hit
        alreadyHit = true;
    }
}
