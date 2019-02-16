using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 10) return;
        Turn.turn = !Turn.turn;
        Rigidbody rb2 = collision.gameObject.GetComponent<Rigidbody>();

        Destroy(collision.gameObject);
        //rb.AddExplosionForce(1000, Vector3.zero, 10);
        Destroy(gameObject);
    }
}
