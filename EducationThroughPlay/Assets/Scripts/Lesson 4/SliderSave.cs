using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderSave : MonoBehaviour
{
    // Variables to hold the volume slider and text for value
    [SerializeField] private TextMeshProUGUI sliderTextUI;
    [SerializeField] private Slider panelSlider;

    // Function to change the text to represent value, called by the slider
    public void SliderChange()
    {
        // The values come in as whole numbers between 1 and 10 on slider, this adjusts
        float updatedValue = panelSlider.value/10;

        // Set Text
        sliderTextUI.text = "Current Value: " + updatedValue.ToString();
    }
}
