using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        print(transform.up);
        rb.AddForce(transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
