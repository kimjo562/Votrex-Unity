using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksBehaviour : MonoBehaviour
{
    public GameObject brickParticle;

    // Called everytime something of this object gets hit
    private void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GameManager.instance.destroyBrick();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
