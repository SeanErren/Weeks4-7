using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCrates : MonoBehaviour
{
    public GameObject prefab;

    List<SpinObject> spinScripts = new List<SpinObject>();

    bool isSpinning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            addPrefab();
        }

        if (isSpinning)
        {
            foreach (SpinObject crate in spinScripts)
            {
                crate.startSpin();
            }
        }
        else
        {
            foreach (SpinObject crate in spinScripts)
            {
                crate.stopSpin();
            }
        }
    }

    public void addPrefab()
    {
        //Creating a new crate and saving it in a temporaty game object
        GameObject tempObject = Instantiate(prefab, new Vector2(Random.Range(-3,3), Random.Range(-3, 3)), Quaternion.identity);

        //Adding the object's script to the list
        spinScripts.Add(tempObject.GetComponent<SpinObject>());
    }

    public void startSpin()
    {
        isSpinning = true;
    }
    public void stopSpin()
    {
        isSpinning = false;
    }
}
