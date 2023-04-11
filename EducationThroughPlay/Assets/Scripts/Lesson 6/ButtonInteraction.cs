// Cohen Nichols ButtonInteraction script for starting the nav mesh agent to move
// this one controlls Ai_NavMesh.cs


using UnityEngine;
using TMPro;

public class ButtonInteraction : MonoBehaviour
{
    // Reference to the text object that displays the "press E to interact" message
    public TextMeshProUGUI interactionText;

    // Reference to the button object's collider
    private Collider buttonCollider;

    // Reference to the player object
    public GameObject player;

    // Reference to the Ai_NavMesh script
    public Ai_NavMesh aiNavMesh;

    // The maximum distance at which the player can interact with the button
    public float interactionDistance = 3.0f;

    // A boolean to track if the player is close enough to interact with the button
    private bool isInRange = false;

    // A boolean to track if the button can be interacted with
    public bool isInteractable = true;

    // An array of targets for the AI agent to move towards
    public Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the button's collider
        buttonCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is close enough to interact with the button
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= interactionDistance)
        {
            isInRange = true;
        }
        else
        {
            isInRange = false;
        }

        // Check if the player is pressing the E key and if the button is interactable
        if (isInRange && isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            // Call the OnButtonInteract() method to perform the interaction with the button
            OnButtonInteract();
        }

        // Display the "press E to interact" message if the player is close enough to interact with the button
        // and the button is interactable
        if (isInRange && isInteractable)
        {
            interactionText.text = "Press E to interact";
        }
        else
        {
            interactionText.text = "";
        }
    }

    // This method is called when the player interacts with the button
    void OnButtonInteract()
{
    // Set isInteractable to false to prevent further interaction with the button
    isInteractable = false;

    // Do something when the button is interacted with, e.g. play a sound, animate the button, etc.

    // If needed, you can also call methods on other scripts or game objects here,
    // e.g. Ai_NavMesh script to move an AI to a new location.
    if (aiNavMesh != null && aiNavMesh.targets != null && aiNavMesh.targets.Length > 0)
    {
        aiNavMesh.SetTargets(aiNavMesh.targets);
        aiNavMesh.isMoving = true;
    }
}

} // end of script



