// Cohen Nichols SecondButton script for starting the nav mesh agents to move
// this one controlls AiFollowPlayer.cs

using UnityEngine;
using TMPro;

public class SecondButton : MonoBehaviour
{
    public TextMeshProUGUI interactionText;
    public KeyCode interactKey = KeyCode.E;

    public AiFollowPlayer aiFollowPlayer;

    private bool isInRange;

    private void Start()
    {
        interactionText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("Button clicked!");

            // Call the Ai_NavMesh script's Start function
            if (aiFollowPlayer != null)
            {
                aiFollowPlayer.Start();
            }
        }
    }
}
