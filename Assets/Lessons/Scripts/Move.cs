using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.setActive = false make Start and Update not run
        transform.position += transform.right * Time.deltaTime;
    }
}
