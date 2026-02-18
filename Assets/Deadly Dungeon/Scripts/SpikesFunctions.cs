using UnityEngine;

public class SpikesFunctions : MonoBehaviour
{
    public GameObject lara;
    EventDrivenLara laraDetails;

    SpriteRenderer sp;

    bool hasLostHealth = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);

        laraDetails = lara.GetComponent<EventDrivenLara>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }

    public void loseHealth()
    {
        if (sp.bounds.Contains(lara.transform.position))
        {
            laraDetails.health--;
        }
    }
}
