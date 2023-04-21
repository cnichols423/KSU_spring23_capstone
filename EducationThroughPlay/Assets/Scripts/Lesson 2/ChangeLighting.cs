using UnityEngine;

public class ChangeLighting : MonoBehaviour

{
    public Light targetLight;
    public Color[] colors;
    public float detectionRadius = 2.0f;

    private bool playerNearby = false;
    private int currentColorIndex = 0;

    void Start()
    {
        targetLight.color = colors[currentColorIndex];
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q))
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            targetLight.color = colors[currentColorIndex];
        }

        float distanceToPlayer = Vector3.Distance(transform.position,
                                                  GameObject.FindGameObjectWithTag("Player").transform.position);
        playerNearby = (distanceToPlayer <= detectionRadius);
    }
}