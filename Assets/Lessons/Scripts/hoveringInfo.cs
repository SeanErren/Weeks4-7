using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class hoveringInfo : MonoBehaviour
{
    TextMeshProUGUI text;

    public List<SpriteRenderer> sprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Is there an object the mouse is currently hovering over
        bool isHovering = false;
        //If there are sprites to check
        if (sprites.Count > 0)
        {
            //Go over each sprite
            for (int i = 0; i < sprites.Count; i++) {
                //Check if the mouse is on top of the sprite's hitbox
                if (sprites[i].bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())))
                {
                    text.text = sprites[i].name;
                    isHovering = true; //There is an object hovered on
                }
            }
        }

        //If not hovering over an object set the text to nothing
        if (!isHovering)
        {
            text.text = "";
        }
    }
}
