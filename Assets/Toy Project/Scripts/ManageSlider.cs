using UnityEngine;
using UnityEngine.UI;

public class ManageSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject topBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = 100;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lowerHP(int amount)
    {
        slider.value -= amount;
    }
}
