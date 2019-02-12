using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    private float lastJ;
    public GameObject original;
    public Transform reference;
    private Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        lastJ = 0;
        coroutine = StartCoroutine(example());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.C))
        {
            StopCoroutine(coroutine);
        }

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

            Instantiate(original, reference.position, reference.rotation);
        }

        lastJ = j;
    }

    //new concept!
    //COROUTINE
    //- pseudo concurrence
    //- run several flows of code at the same time
    IEnumerator example() {
        while (true)
        {
            yield return new WaitForSeconds(1);
            print("this will still work");
        }
        
    }
}
