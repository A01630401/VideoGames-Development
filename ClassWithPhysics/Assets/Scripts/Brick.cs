using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            rb.AddExplosionForce(1000, Vector3.zero, 10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("COLLIDING");

        if (collision.gameObject.layer != 10) return;

        //testing - destroy physics on projectile
        Rigidbody rb2 = collision.gameObject.GetComponent<Rigidbody>();
        //Destroy(rb2);

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
