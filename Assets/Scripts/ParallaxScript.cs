using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float startingPos, //This is the starting position of the sprites.
        lengthOfSprite; //This is the length of the sprites.
    public float amountOfParallax; //This is amount of parallax scroll. 
    public Camera mainCamera; //Reference of the camera.

    // Start is called before the first frame update
    void Start()
    {
        //Getting the starting X position of sprite.
        startingPos = transform.position.x;
        //Getting the length of the sprites.
        lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = mainCamera.transform.position;
        float temp = position.x * (1 + amountOfParallax);
        float distance = position.x * -amountOfParallax;

        Vector3 newPosition = new Vector3(startingPos + distance, transform.position.y, transform.position.z);

        transform.position = newPosition;

        if (temp > startingPos + (lengthOfSprite / 2)){
            startingPos += lengthOfSprite;
        }
        else if (temp < startingPos - (lengthOfSprite / 2))
        {
            startingPos -= lengthOfSprite;
        }
    }
}
