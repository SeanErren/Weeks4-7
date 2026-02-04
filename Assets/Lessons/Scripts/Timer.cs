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
        timerSlider.value -= Time.deltaTime;
        if (timerSlider.value <= 0 )
        {
            timerSlider.value = timerSlider.maxValue;
        }
    }
}
