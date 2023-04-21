using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linked: MonoBehaviour
{
    public Material[] materials;
    public float rotationSpeed = 1f;
    private int currentIndex = 0;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeObjectMaterial();
        }
    }

    private void ChangeObjectMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && materials.Length > 0)
        {
            currentIndex = (currentIndex + 1) % materials.Length;
            renderer.material = materials[currentIndex];
        }
    }
}