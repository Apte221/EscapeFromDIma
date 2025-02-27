using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public TMP_Text valueText;

    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
        slider.onValueChanged.AddListener(UpdateValue);
        UpdateValue(slider.value);
    }

    void UpdateValue(float value)
    {
        valueText.text = value.ToString("F0") + "%";;
    }
}