using UnityEngine;

public class SpinObject : MonoBehaviour
{
    float spinSpeed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, spinSpeed);
    }

    //Sets the spin speed to 100 to start spinning
    public void startSpin()
    {
        spinSpeed = 100;
    }

    //Sets the spin speed to 0 to stop spinning
    public void stopSpin()
    {
        spinSpeed = 0;
    }
}
