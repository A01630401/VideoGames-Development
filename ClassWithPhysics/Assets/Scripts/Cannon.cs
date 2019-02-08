using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    private float lastJ;
    public GameObject original;

    // Start is called before the first frame update
    void Start()
    {
        lastJ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate( 0, 0, h * 10 * Time.deltaTime);

        float j = Input.GetAxis("Jump");

        if (lastJ == 0 && j == 1)
        {
            //shoot something
            print("SHOOTING");


            //INSTANTIATE
            // (pretty much just clone)
            // - needs a reference

            Instantiate(original);
        }

        lastJ = j;
    }
}
