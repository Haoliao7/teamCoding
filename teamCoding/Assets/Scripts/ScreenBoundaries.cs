using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); //set boundaries
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x; //obj width
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y; //obj height
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position; //set position
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1); //clamp x boundary
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1); //clamp y boundary
        transform.position = viewPos; //set to new position
    }
}