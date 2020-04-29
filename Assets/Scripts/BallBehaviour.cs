using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float ballIntiVelocity = 600f;

    private Rigidbody rb;
    private bool ballInPlay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse click to shoot ball while its not active
        if(Input.GetButton("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballIntiVelocity, ballIntiVelocity, 0));
        }
    }
}
