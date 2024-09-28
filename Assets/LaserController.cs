using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float laserSpeed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        myRB.velocity = Vector3.right*laserSpeed;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // don't collide w/ non-asteroids
        if (!collision.gameObject.CompareTag("Asteroid")) return;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
