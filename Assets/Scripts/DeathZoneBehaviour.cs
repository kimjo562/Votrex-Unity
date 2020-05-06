using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{
    public GameManagerScript gameManager;
    private void OnTriggerEnter(Collider col)
    {
        // Lose a life and destroy the Ball
        gameManager.loseLife();

        GameObject tempGameObject = col.gameObject;
        Destroy(tempGameObject);
    }
}
