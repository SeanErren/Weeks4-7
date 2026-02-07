using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerPercentage : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = 20;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = slider.value + "%";
    }
}
