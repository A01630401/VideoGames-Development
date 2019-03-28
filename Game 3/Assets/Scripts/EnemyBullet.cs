using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 50, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 10) {
            collision.gameObject.transform.eulerAngles = new Vector3(180, 180, 0);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
