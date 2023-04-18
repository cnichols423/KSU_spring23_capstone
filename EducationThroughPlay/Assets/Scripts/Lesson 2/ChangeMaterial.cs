using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject objectToChange;
    public Material newMaterial;
    public Button ButtonScript;

    void Start()
    {
        ButtonScript.onClick.AddListener(ChangeObjectMaterial);
    }

    void ChangeObjectMaterial()
    {
        Renderer renderer = objectToChange.GetComponent<Renderer>();
        renderer.material = newMaterial;
    }
}
