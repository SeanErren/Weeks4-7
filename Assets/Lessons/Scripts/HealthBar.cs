using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    SpriteRenderer target;
    public float playerHealth = 3;
    public float damageDone = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GetComponent<SpriteRenderer>();
        healthBar.maxValue = playerHealth;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //If the mouse is pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Getting the mouse's position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //If the mouse is within the bounds of target
            if (target.bounds.Contains(mousePos))
            {
                loseHealth();
            }
        }
    }

    void loseHealth()
    {
        if (healthBar.value > 0)
            healthBar.value -= damageDone;
        if (healthBar.value <= 0)
            gameObject.SetActive(false);
    }

    public void gainHealth()
    {
        healthBar.value += damageDone;
        gameObject.SetActive(true);
    }
}
