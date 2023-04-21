using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject targetObject;
    public Material targetMaterial;
    public Light targetLight;
    public Color targetColor;
    public GameObject destinationObject;
    public Color lineColor = Color.red;
    public float lineWidth = 0.2f;

    private Renderer targetRenderer;

    void Start()
    {
        targetRenderer = targetObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (targetRenderer.material == targetMaterial && targetLight.color == targetColor)
        {
            DrawLineToDestination();
        }
    }

    private void DrawLineToDestination()
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = transform.position;
        positions[1] = destinationObject.transform.position;
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        Material lineMaterial = new Material(Shader.Find("Standard"));
        lineMaterial.color = lineColor;
        lineRenderer.material = lineMaterial;
        lineRenderer.SetPositions(positions);
    }
}