using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsLessOne : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;

    private void Show()
    {
        containerGameObject.SetActive(true);
    }

    public void Interact()
    {
        Show();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
