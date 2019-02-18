using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!Turn.turn)
            rb.AddForce(transform.up * 150, ForceMode.Impulse);
        else
            rb.AddForce(transform.up * -150, ForceMode.Impulse);

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Tank")
            print("Tank 2 wins");
        else if (collision.transform.name == "Tank 2")
            print("Tank 1 wins");
    }
}
