using UnityEngine;

public class ButtonScripting : MonoBehaviour
{
    public GameObject targetObject;
    public Material[] materials;
    public float detectionRadius = 2.0f;

    private Renderer targetRenderer;
    private bool playerNearby = false;
    private int currentMaterialIndex = 0;

    void Start()
    {
        targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material = materials[currentMaterialIndex];
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
            targetRenderer.material = materials[currentMaterialIndex];
        }

        float distanceToPlayer = Vector3.Distance(transform.position,
                                                  GameObject.FindGameObjectWithTag("Player").transform.position);
        playerNearby = (distanceToPlayer <= detectionRadius);
    }
}