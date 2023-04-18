using UnityEngine;
using UnityEngine.UI;

public class ChangeLighting : MonoBehaviour
{
    public Button button;
    public GameObject objectToChange;
    public Light lightSource;

    private bool isLightOn = true;

    void Start()
    {
        button.onClick.AddListener(ChangeObjectLighting);
    }

    void ChangeObjectLighting()
    {
        isLightOn = !isLightOn;
        objectToChange.GetComponent<Renderer>().material.color = isLightOn ? Color.white : Color.black;
        lightSource.intensity = isLightOn ? 1.0f : 0.0f;
    }
}