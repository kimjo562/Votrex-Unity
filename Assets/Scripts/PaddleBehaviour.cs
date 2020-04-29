using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    Vector3 mousePos;
    public float speed = 1.0f;
    Rigidbody rigidBody;
    Vector3 position = new Vector3(0f, 0f, 0f);

    //public Vector3 paddlePos = new Vector3(0, 0, 0);

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        position = Vector3.Lerp(transform.position, mousePos, speed);

        //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //// Allows to limit a number between certain values (So Paddle can't leave a certain area.)
        //paddlePos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
        //transform.position = paddlePos; 
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(position);
    }
}
