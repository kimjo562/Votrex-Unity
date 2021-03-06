﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    public Camera cam;
    public float speed = 1.0f;
    public Vector3 paddlePos = new Vector3(0f, 0f, 0f);

    // Update is called once per frame
    //void Update()
    //{
    //    float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
    //    // Allows to limit a number between certain values (So Paddle can't leave a certain area.)
    //    paddlePos = new Vector3(Mathf.Clamp(xPos, -8.5f, 8.5f), 0f, 0f);
    //    transform.position = paddlePos;
    //}

    private void OnGUI()
    {
        // Get current event for GUI(EX: Mouse Position updated)
        Event currentEvent = Event.current;
        // Create new variable to store mouse position
        Vector2 mousePos = new Vector2();
        // Set mouse position to be the current x value of the mouse on screen and subtract y from pixel height  so its not inverted
        mousePos.Set(currentEvent.mousePosition.x, cam.pixelHeight - currentEvent.mousePosition.y);
        // Convert the mousePos on screen to world space and set its x value to be our new x position
        float xPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - cam.transform.position.z)).x;
        // Set the transforms x to be our new x position
        paddlePos = new Vector3(xPos, transform.position.y, transform.position.z);
        paddlePos = new Vector3(Mathf.Clamp(xPos, -8.5f, 8.5f), 0f, 0f);
        transform.position = paddlePos;
    }
}
