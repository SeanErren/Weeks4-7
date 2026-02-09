using UnityEngine;

public class Rotator2000 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles += new Vector3(0,0, -150 * Time.deltaTime);
    }
}
