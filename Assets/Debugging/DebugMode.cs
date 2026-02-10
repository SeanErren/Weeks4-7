using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    public GameObject shapePrefab;
    public int shapeCount;
    List<GameObject> shapes;
    
    void Start()
    {
        for(int i = 0; i < shapeCount; i++)
        {
            GameObject go = Instantiate(shapePrefab, new Vector3(i * 2, 0, 0), Quaternion.identity);
            AddShapeToList(go);
        }
    }

    void AddShapeToList(GameObject shape)
    {
        shapes.Add(shape);
    }
}
