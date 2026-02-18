using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool isInHazard = false;

    public UnityEvent OnEnterSensor, OnExitSensor;

    public UnityEvent<float> onRandomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hazard.bounds.Contains(transform.position))
        {
            if (isInHazard)
            {
                //We were in the hazard and still are
            }
            else
            {
                //First frame entering the hazard
                isInHazard = true;
                OnEnterSensor.Invoke();
            }   
        }
        else
        {
            if (isInHazard)
            {
                //First frame leaving the hazard
                isInHazard = false;
                OnExitSensor.Invoke();
                onRandomNumber.Invoke(Random.Range(0, 100));
            }
            else
            {
                //Already outside of the hazard
            }
        }
    }

    public void showNumeber(float randomNum)
    {
        Debug.Log(randomNum);
    }
}
