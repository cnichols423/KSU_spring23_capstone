using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public Button button;
    public GameObject objectToActivate;

    void Start()
    {
        button.onClick.AddListener(ActivateObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateObject();
        }
    }

    void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}