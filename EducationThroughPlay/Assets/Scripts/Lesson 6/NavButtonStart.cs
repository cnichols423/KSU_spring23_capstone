using UnityEngine;
using UnityEngine.UI;

public class NavButtonStart : MonoBehaviour
{
    public Button navButton;  // reference to the button that triggers the navigation
    
    private Ai_NavMesh aiNavMesh; // reference to the AI navigation script

    // Start is called before the first frame update
    void Start()
    {
        aiNavMesh = GetComponent<Ai_NavMesh>(); // get the reference to the navigation script on this game object
        navButton.onClick.AddListener(StartNavigation); // add a listener to the button to start navigation
    }

    // method to start the AI navigation
    void StartNavigation()
    {
        aiNavMesh.enabled = true; // enable the navigation script
    }
}
