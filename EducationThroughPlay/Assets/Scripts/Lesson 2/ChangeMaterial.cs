using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject objectToChange;
    public Material newMaterial;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(ChangeObjectMaterial);
    }

    void ChangeObjectMaterial()
    {
        Renderer renderer = objectToChange.GetComponent<Renderer>();
        renderer.material = newMaterial;
    }
}
