using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.up * 50, ForceMode.Impulse);
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
