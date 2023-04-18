using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject startObject;
    public GameObject endObject;
    public Material lineMaterial;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, startObject.transform.position);
        lineRenderer.SetPosition(1, endObject.transform.position);
    }
}