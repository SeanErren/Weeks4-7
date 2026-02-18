using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject player;

    List<CarValues> cars = new List<CarValues>();

    float carsAmount = 10;
    float carBaseHeight = -5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < carsAmount; i++)
        {
            cars.Add(Instantiate(carPrefab, new Vector3(0, i + carBaseHeight, 0), Quaternion.identity).GetComponent<CarValues>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CarValues car in cars)
        {
            //car.GetComponent<SpriteRenderer>().bounds.Contains(player.transform);
        }
    }
}
