using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Slider powerSlider;
    public GameObject prefab; //The sets prefab
    public GameObject requirementPrefab; //The requirement prefab
    public TextMeshProUGUI scoreText;
    public TimerScript timer;
    public Button validateButton;
    public GameObject finalScoreHolder; //The setActive = false game object that hides the TextMesh (since there is no setActive for TextMesh)
    public TextMeshProUGUI finalScore; //The TextMesh containing the final score
    public GameObject rotater;

    List<GameObject> targets = new List<GameObject>();
    GameObject requirementObject;
    float requirementPercentage = 0;
    float score = 0;

    private float perlinTimeX = 0, perlinTimeY = 10, prelinIncrement = 0.3f;

    //c1 is at the class level so it can be accessed when generating the requirements
    private Color c1;

    //Makes sure that the end actions only happen once
    private bool runEnd = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnRound();
        generateRequirements();
    }

    // Update is called once per frame
    void Update()
    {
        if (!runEnd)
        {
            //If the game is done
            if (timer.hasEnded)
            {
                //Remove the circles
                destroyPrefabs();
                //Disable the validate button
                validateButton.interactable = false;
                //Disable the power bar
                powerSlider.interactable = false;
                //Set the weeeee in motion (hi kit <---- this rotates :) )
                rotater.SetActive(true);
                //Set the final score and make it visible
                finalScoreHolder.SetActive(true);
                //I tried getting the final score from finalScoreHolder (finalScoreHolder.getComponent<TextMeshProUGUI>().text = "Final Score: " + score)
                //But got a Null pointer exception even though the TextMesh is under FinalScoreHolder so I just grabbed it separately from the inspector.
                finalScore.text = "Final Score: " + score;

                runEnd = true;
            }
            //If the game is running
            else
            {
                //Adding an increment to the perlin time
                perlinTimeX += prelinIncrement * Time.deltaTime;
                perlinTimeY += prelinIncrement * Time.deltaTime;

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

                detectHit();
            }
        }
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

        c1 = Random.ColorHSV();
        Color c2 = Random.ColorHSV();
        Color c3 = Random.ColorHSV();

        //MAKING SURE THAT THE COLORS ARE DIFFERENT ENOUGH FROM EACH OTHER - NOT EXITING THE LOOP SOMETIMES <--- NEED TO FIX
        //making sure that c2 is different enough from c1
        //float colorDifference = 0.2f;
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
        //Destroys the circle sets
        for (int i = 0; i < targets.Count; i++)
        {
            Destroy(targets[i]);
        }
        targets.Clear();

        //Destroys the requirement
        Destroy(requirementObject);
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
    //Detect a hit and remove the damage amount from the correct slider
    void detectHit()
    {
        //If the mouse was pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Check if it was pressed over the targets
            for (int i = 0;i < targets.Count;i++)
            {
                //If the mouse's position in world space converted to Vector2 (to lose the -10 z) is within the bounds of the spriteRenderer of the circle
                if (targets[i].GetComponent<SpriteRenderer>().bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())))
                {
                    //Remove the HP from the same colored bar, corrosponding to the amount in the slider (if the slider reads 8 - remove 8HP)
                    //The corrosponding bar is always the one before (unless it's the first one in which case it's the last) due to how the colors are asigned
                    if (i > 0)
                        targets[i - 1].GetComponent<ManageSlider>().lowerHP(powerSlider.value);
                    else
                        targets[targets.Count - 1].GetComponent<ManageSlider>().lowerHP(powerSlider.value);
                }   
            }
        }
    }
    //Generates the requiremenets bar and percentage
    void generateRequirements()
    {
        //Instantiating the prefab and saving it in the object
        requirementObject = Instantiate(requirementPrefab);
        //Getting the slider manager from the requirement object.
        ManageSlider manager = requirementObject.GetComponent<ManageSlider>();
        manager.topBar.GetComponent<Image>().color = c1;

        //Ends at 70 to force more than 1 click from the user (max power is 20), starts at 1 so no spam, remove all health is involved
        requirementPercentage = Random.Range(1, 70);
        manager.slider.maxValue = 100;
        //NOT WORKING: The slider's value resets to 100/100 for some reason after setting it to the random amount, using the percentage to check the values instead
        manager.slider.value = requirementPercentage;
        manager.percentage.text = requirementPercentage + "%";
    }
    //Check for validation and enact validation actions if validated (add 1 to the score and regenerate the circle sets
    public void validate()
    {
        //If the requirement bar is equal to the target's bar
        if (requirementPercentage == targets[2].GetComponent<ManageSlider>().slider.value)
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        //Spawns a new round of sets and requirement after validation
        spawnRound();
        generateRequirements();
    }
}

