using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ken : MonoBehaviour
{

    private Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        transform.Translate(h * 5 * Time.deltaTime, 0, 0);
        a.SetFloat("moving", h);
    }
}
