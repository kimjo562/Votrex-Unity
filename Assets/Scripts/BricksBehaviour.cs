using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksBehaviour : MonoBehaviour
{
    public ScoreBehaviour scoreKeeper;
    public GameObject brickParticle;

    // Called everytime something of this object gets hit
    private void OnCollisionEnter()
    {
        // Clone/Create Particle Effect where the ball hit the brick
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        scoreKeeper.brickCount--;
        Destroy(gameObject);
    }
}