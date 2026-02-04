using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Duckie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the mouse is NOT over an element in the UI
        if (!EventSystem.current.IsPointerOverGameObject())
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                transform.position = mousePos;
            }
    }
}
