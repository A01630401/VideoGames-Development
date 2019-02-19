using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = new Rigidbody();
        rb.AddForce(transform.up, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Wall 1")
            Destroy(gameObject);
        else if (collision.gameObject.name == "Wall 2")
            Destroy(gameObject);
        else if (collision.gameObject.name == "Wall 3")
            Destroy(gameObject);
        else if (collision.gameObject.name == "Wall 4")
            Destroy(gameObject);
    }
}
