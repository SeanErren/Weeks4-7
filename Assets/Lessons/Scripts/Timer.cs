using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    //float timerValue = 0;
    public float timerLimit = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerSlider.maxValue = timerLimit;
        timerSlider.value = timerSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //When using "Whole Numbers" in the componant the digits after the point get cut off meaning that it removing 0 every time and gets stuck.
        //It's good practice to use a saparate variable to make sure that I don't lose the numbers after the dot and in general is good practice.
        timerSlider.value -= Time.deltaTime;
        if (timerSlider.value <= 0 )
        {
            timerSlider.value = timerSlider.maxValue;
        }
    }
}
