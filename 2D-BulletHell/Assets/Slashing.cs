using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slashing : MonoBehaviour
{
    public float slashingRange;
    private Vector2 mouseDirection;
    public GameObject slashObject;
    public float slashTimeDuration;
    private float slashCDTimer;

    // Start is called before the first frame update
    void Start()
    {
        slashCDTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction vector from player to mouse cursor
        Vector2 direction = (mouseDirection - (Vector2)transform.position).normalized;
        // Calculate the angle in radians between the player's forward direction (e.g., right) and the mouse direction
        float angle = Mathf.Atan2(direction.y, direction.x);
        // Convert the angle to degrees
        float degrees = angle * Mathf.Rad2Deg;
        //Debug.Log(degrees);

        slashCDTimer -= Time.deltaTime;
        if (slashCDTimer <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //Calculate the degreess offset of where the position would be spawned.
                Vector2 spawnObjectDegreesOffset = transform.position + (Quaternion.Euler(0, 0, degrees) * Vector2.right) * slashingRange;
                GameObject newObject = Instantiate(slashObject, spawnObjectDegreesOffset, Quaternion.identity);
                newObject.transform.SetParent(gameObject.transform);
                //Rotate the object
                newObject.transform.rotation = Quaternion.Euler(0f, 0f, degrees);
                slashCDTimer = slashTimeDuration;
                Destroy(newObject, 0.05f);

                
            }
            
        }



        
        
    }
}
