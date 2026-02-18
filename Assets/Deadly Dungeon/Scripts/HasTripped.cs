using UnityEngine;
using UnityEngine.Events;

public class HasTripped : MonoBehaviour
{
    public GameObject lara;
    SpriteRenderer larasp;
    bool isBroken = false;

    public UnityEvent wireBorken;

    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        larasp = lara.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (larasp.bounds.Contains(transform.position))
        {
            wireBorken.Invoke();
            isBroken = true;
        }

        //if (spriteRenderer.bounds.Contains(lara.transform.position))
        //{
        //    if (isBroken)
        //    {

        //    }
        //    else
        //    {
        //        wireBorken.Invoke();
        //        isBroken = true;
        //    }
        //}
    }
}
