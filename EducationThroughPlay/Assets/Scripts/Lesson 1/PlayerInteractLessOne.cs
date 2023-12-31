using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractLessOne : MonoBehaviour
{
    public GameObject ExitGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the player presses "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // A float that controls the range of player interaction
            float interactRange = 2f;

            // Make a collider array and store every object that is overlapping in an array
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            // For each collider in that array
            foreach (Collider collider in colliderArray)
            {
                //
                if (collider.TryGetComponent(out ButtonsLessOne button))
                {
                    button.Interact();
                    break;
                }
            }

        }
        if(Input.GetKeyDown(KeyCode.Q)){
            // A float that controls the range of player interaction
            float interactRange = 2f;

            // Make a collider array and store every object that is overlapping in an array
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            // For each collider in that array
            foreach (Collider collider in colliderArray)
            {
                //
                if (collider.gameObject == ExitGameObject)
                {
                    SceneManager.LoadScene("Nav Hub");
                    break;
                }
            }
        }
    }
}
