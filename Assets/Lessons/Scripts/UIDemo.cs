using UnityEngine;
using UnityEngine.InputSystem;

public class UIDemo : MonoBehaviour
{
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            randomizeColor();
        }
    }

    public void randomizeColor()
    {
        sr.color = Random.ColorHSV();
    }

    public void changeSize(float size)
    {
        transform.localScale = Vector2.one * size;
    }
}
