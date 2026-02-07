using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> targets = new List<GameObject>();

    private float perlinTimeX = 0, perlinTimeY = 10, prelinIncrement = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Adding an increment to the perlin time
        perlinTimeX += prelinIncrement * Time.deltaTime;
        perlinTimeY += prelinIncrement * Time.deltaTime;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            spawnRound();

        foreach (GameObject target in targets)
        {
            //Adding a big increment to perlin time to differentiate between the targets
            perlinTimeX += 1;
            perlinTimeY += 1;
            //Setting a new position based on a mapped perlin noise for x and y as well as off-centering that position for the sake of the UI elements
            target.transform.position = new Vector2(mapFloat(Mathf.PerlinNoise(perlinTimeX, perlinTimeX), 0, 1, -8, 8) - 1
                , mapFloat(Mathf.PerlinNoise(perlinTimeY, perlinTimeY), 0, 1, -5, 5) + 1.5f);
        }
        //Removing the amounts added to differentiate between targets so that each target can move correctly next frame
        perlinTimeX -= targets.Count;
        perlinTimeY -= targets.Count;
    }

    //Spawns 3 circles sets
    public void spawnRound()
    {
        //Setting new starting positions for the circles
        perlinTimeX += 100;
        perlinTimeY += 100;

        //GENERATE COLORS FOR PREFABS
        //--------------------------------------------------------------------------------------------------------------------
        //I don't know why the colors return values between 0 and 1 instead of 0 - 255
        float colorDifference = 0.2f;

        Color c1 = Random.ColorHSV();
        Color c2 = Random.ColorHSV();
        Color c3 = Random.ColorHSV();

        Debug.Log(c1.r + ", " + c2.r + ", " + c3.r);

        //MAKING SURE THAT THE COLORS ARE DIFFERENT ENOUGH FROM EACH OTHER - NOT EXITING THE LOOP SOMETIMES <--- NEED TO FIX
        //making sure that c2 is different enough from c1
        //while (true)
        //{
        //    //If any of the RGB value are x away between c1 and c2 (making sure that the color is different enough), exit
        //    if ((c1.r > c2.r + colorDifference || c1.r < c2.r - colorDifference)
        //        || (c1.g > c2.g + colorDifference || c1.g < c2.g - colorDifference)
        //        || (c1.b > c2.b + colorDifference || c1.b < c2.b - colorDifference))
        //        break;
        //    //If not, regenerate c2's color
        //    else
        //        c2 = Random.ColorHSV();
        //}
        //////Making sure that c3 is different enough from both c1 and c2
        //while (true)
        //{
        //    //If any of the RGB value are x away between c3 and c1 (making sure that the color is different enough)
        //    if ((c3.r > c1.r + colorDifference || c3.r < c1.r - colorDifference)
        //        || (c3.g > c1.g + colorDifference || c3.g < c1.g - colorDifference)
        //        || (c3.b > c1.b + colorDifference || c3.b < c1.b - colorDifference))
        //        //And if any of the RGB value are x away between c3 and c2 (making sure that the color is different enough), exit
        //        if ((c3.r > c2.r + colorDifference || c3.r < c2.r - colorDifference)
        //        || (c3.g > c2.g + colorDifference || c3.g < c2.g - colorDifference)
        //        || (c3.b > c2.b + colorDifference || c3.b < c2.b - colorDifference))
        //            break;
        //        //If not, regenerate c3's color
        //        else
        //            c3 = Random.ColorHSV();
        //}
        //--------------------------------------------------------------------------------------------------------------------

        //CREATE SETS
        //--------------------------------------------------------------------------------------------------------------------
        //Destroy existing pefabs
        destroyPrefabs();

        //FIRST SET - CIRCLE = COLOR 1, BAR = COLOR 2
        spawnPrefab();
        //Get the circle's sprite renderer and change its color.
        targets[targets.Count - 1].GetComponent<SpriteRenderer>().color = c1;
        //Get the script that controls the slider and color the its top bar GameObject variable.
        targets[targets.Count - 1].GetComponent<ManageSlider>().topBar.GetComponent<Image>().color = c2;

        //SECOND SET - CIRCLE = COLOR 2, BAR = COLOR 3
        spawnPrefab();
        //Get the circle's sprite renderer and change its color.
        targets[targets.Count - 1].GetComponent<SpriteRenderer>().color = c2;
        //Get the script that controls the slider and color the its top bar GameObject variable.
        targets[targets.Count - 1].GetComponent<ManageSlider>().topBar.GetComponent<Image>().color = c3;

        //THIRD SET - CIRCLE = COLOR 3, BAR = COLOR 1
        spawnPrefab();
        //Get the circle's sprite renderer and change its color.
        targets[targets.Count - 1].GetComponent<SpriteRenderer>().color = c3;
        //Get the script that controls the slider and color the its top bar GameObject variable.
        targets[targets.Count - 1].GetComponent<ManageSlider>().topBar.GetComponent<Image>().color = c1;
        //--------------------------------------------------------------------------------------------------------------------
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
    //Remaps a current float value with a certain possible range to the same value in a different range
    float mapFloat(float value, float currentMin, float currentMax, float desiredMin, float desiredMax)
    {
        //The value of the float if the currentMin value started at 0
        float valueFrom0 = value - currentMin;
        //The max value if the minimum value started at 0
        float currentRange = currentMax - currentMin;
        //What's the ratio between the value and the range that it's generated in (after setting the range to be from 0 to x).
        //Example: If the value is 3 and the range is -1 to 4, the valueFrom0 would be 4 (3 - -1), the currentRange would be 5 (getting rid of the minus).
        //The ratio would then be the current value out of the total, meaning: 3 of 5 starting from 0 (instead of 3 of 4 starting at -1) - 3/5 (valueFrom0 / currentRange)
        float ratio = valueFrom0 / currentRange;

        //Doing the same with the desired range (changing it so that the starting point is 0)
        //If the min is 5 and the max is 15: 15 - 5 = 10 which is the range starting at 0.
        float desiredRange = desiredMax - desiredMin;
        //Taking the ratio between the two numbers from before (3/5 in the example) and multiplying it by the range we get the exact number in the new range (3/5 * 10 = 6/10 * 10 = 6).
        float newValue = desiredRange * ratio;
        //Adding back the min value so that the ratio is kept but the new value is in relation to the desired starting point instead of 0.
        //6 + 5 = 11 (11 in the range of 5 to 15 instead of 6 in the range of 0 - 10)
        float finalValue = newValue + desiredMin;

        return finalValue;
    }
}

