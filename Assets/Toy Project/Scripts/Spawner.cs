using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> targets = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            spawnRound();
    }

    //Spawns 3 circles sets
    public void spawnRound()
    {
        //GENERATE COLORS FOR PREFABS
        //--------------------------------------------------------------------------------------------------------------------
        int colorDifference = 30;

        Color c1 = Random.ColorHSV();
        Color c2 = Random.ColorHSV();
        Color c3 = Random.ColorHSV();

        //making sure that c2 is different enough from c1
        //while (true)
        //{
        //    //If any of the RGB value are 30+ away between c1 and c2 (making sure that the color is different enough), exit
        //    if ((c1.r > c2.r + colorDifference || c1.r < c2.r - colorDifference)
        //        || (c1.g > c2.g + colorDifference || c1.g < c2.g - colorDifference)
        //        || (c1.b > c2.b + colorDifference || c1.b < c2.b - colorDifference))
        //        break;
        //    //If not, regenerate c2's color
        //    else
        //        c2 = Random.ColorHSV();
        //}
        ////Making sure that c3 is different enough from both c1 and c2
        //while (true)
        //{
        //    //If any of the RGB value are 30+ away between c1 and c3 (making sure that the color is different enough)
        //    if ((c1.r > c3.r + colorDifference || c1.r < c3.r - colorDifference)
        //        || (c1.g > c3.g + colorDifference || c1.g < c3.g - colorDifference)
        //        || (c1.b > c3.b + colorDifference || c1.b < c3.b - colorDifference))
        //        //And if any of the RGB value are 30+ away between c2 and c3 (making sure that the color is different enough), exit
        //        if ((c2.r > c3.r + colorDifference || c2.r < c3.r - colorDifference)
        //        || (c2.g > c3.g + colorDifference || c2.g < c3.g - colorDifference)
        //        || (c2.b > c3.b + colorDifference || c2.b < c3.b - colorDifference))
        //            break;
        //    //If not, regenerate c3's color
        //    else
        //        c3 = Random.ColorHSV();
        //}
        //--------------------------------------------------------------------------------------------------------------------

        //Destroy existing pefabs
        destroyPrefabs();

        int prefabsAmount = 3; //Same as the amount of colors
        for (int i = 0; i < prefabsAmount ; i++)
        {
            spawnPrefab();
            //targets[targets.Count - 1].GetComponent(Image);
        }
    }
        //Clear instantiated objects
        void destroyPrefabs()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            Destroy(targets[i]);
        }
        targets.Clear();
    }
    //Spawns a set of a circle and a bar
    void spawnPrefab()
    {
        targets.Add(Instantiate(prefab, Random.insideUnitCircle, Quaternion.identity));
    }
}
