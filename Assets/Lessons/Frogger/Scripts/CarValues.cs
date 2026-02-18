using UnityEngine;

public class CarValues : MonoBehaviour
{
    Vector3 screenStart = new Vector3(), screenEnd = new Vector3();

    public float speed;
    public Color color;

    bool isLtoR = true;
    float distanceFromScreenEdges = 2;
    float speedRangeStart = 1, speedRangeEnd = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GET SCREEN START AND END
        screenStart = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        screenEnd = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //SET STARTING POSITION AND SPEED
        speed = Random.Range(2, 5);
        randomizeIsLtoR();
        //If the car is moving from the left to the right
        if (isLtoR)
        {
            //Sets the x of the position based on isLToR
            transform.position += new Vector3(screenStart.x - distanceFromScreenEdges, 0, 0);
            speed = Random.Range(speedRangeStart, speedRangeEnd);

            //Turn the car
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        //If the car is moving from left to right
        if (!isLtoR)
        {
            //Sets the x of the position based on isLToR
            transform.position += new Vector3(screenEnd.x + distanceFromScreenEdges, 0, 0);
            speed = Random.Range(speedRangeStart, speedRangeEnd) * -1;

            //Turn the car
            transform.eulerAngles = new Vector3 (0, 0, 90);
        }

        //SET STARTING COLOR
        color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the car
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        //If the car passed the right edge of the screen
        if (transform.position.x > screenEnd.x + distanceFromScreenEdges)
            //Reset the position to the end of the left side of the screen
            transform.position = new Vector3(screenStart.x - distanceFromScreenEdges, transform.position.y, 0);

        //If the car passed the left edge of the screen
        if (transform.position.x < screenStart.x - distanceFromScreenEdges)
            //Reset the position to the end of the right side of the screen
            transform.position = new Vector3(screenEnd.x + distanceFromScreenEdges, transform.position.y, 0);

    }
    // 50 50 chance for isLtoR to be true or false
    void randomizeIsLtoR()
    {
        if (Random.Range(0, 2) == 0)
            isLtoR = true;
        else
            isLtoR = false;
    }

    public Transform getCarPos()
    {
        return transform;
    }
}
