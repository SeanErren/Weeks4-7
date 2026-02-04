using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    SpriteRenderer target;
    public float playerHealth = 3;
    public float damageDone = 0.5f;

    public AudioSource audioSource; //The componant
    public AudioClip hitSound; //The sound file itself
    public AudioClip deathSound; //The sound file itself

    //AudioSource.Play() plays the clip in the AudioSource by starting and stopping it.
    //AudioSource.PlayOneShot(clip) will stack the clips on top of each other, allowing for overlapping layers of sound (up to 32).

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GetComponent<SpriteRenderer>();

        //Setting the max health value and then filling up the bar
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
        {
            healthBar.value -= damageDone;
            //Set the specific clip the audio source uses
            audioSource.clip = hitSound;
            //Play the clip
            audioSource.Play();
        }
        if (healthBar.value == 0) //If the player just died
        {
            //Set the specific clip the audio source uses
            audioSource.clip = deathSound;
            //Play the clip
            audioSource.Play();
        }
        if (healthBar.value <= 0)
            gameObject.SetActive(false);
    }

    public void gainHealth()
    {
        healthBar.value += damageDone;
        gameObject.SetActive(true);
    }
}
