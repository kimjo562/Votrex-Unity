using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.loseLife();
    }
}
