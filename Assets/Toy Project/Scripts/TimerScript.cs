using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Slider timerSlider;
    public GameObject timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerSlider.maxValue = 60;
        timerSlider.value = timerSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        timerSlider.value -= Time.deltaTime;
        if (timerSlider.value <= 0)
            timer.SetActive(false);
    }
}
