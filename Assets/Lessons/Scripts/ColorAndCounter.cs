using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorAndCounter : MonoBehaviour
{
    SpriteRenderer sp;
    public Image cassete;
    public int clickCount;
    public TextMeshProUGUI textMesh;
    public Slider slider;
    public TextMeshProUGUI sliderValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        Color c = Random.ColorHSV();
        sp.color = c;
        cassete.color = c;
    }

    public void AddClick()
    {
        clickCount++;
        //.ToString() if not added to a string.
        textMesh.text = "Click Count: " + clickCount;
    }

    public void ScaleSun(float sliderScale)
    {
        transform.localScale = Vector3.one * sliderScale;
        sliderValue.text = "Slider Value: " + slider.value;
    }
}
