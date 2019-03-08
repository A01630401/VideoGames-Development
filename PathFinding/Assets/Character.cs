using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // stalker
    public Waypoint[] path;
    public float threshold;
    private Coroutine coroutine;
    private IEnumerator enumerator;

    private int current;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        coroutine = StartCoroutine(CheckDistance());
        //enumerator = CheckDistance();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 2, Space.World);

        if (Input.GetKeyUp(KeyCode.Return))
        {
            //StopCoroutine(enumerator);
            StopCoroutine(coroutine);
            //StopAllCoroutines();

        }
    }

    // We need yo check distance on a regulat bassis with the least
    // amount of overhead

    // coroutine!
    IEnumerator CheckDistance()
    {
        while (true)
        {
            // check distance
            float d = Vector3.Distance(transform.position, path[current].transform.position);

            if(d < threshold)
            {
                current++;
                current %= path.Length;
            }

            // wait a little
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnMouseDown()
    {
        // clicked over the object
        print("MOUSE DOWN");
    }

    private void OnMouseEnter()
    {
        // in this frame the pointer is over the object
        // on the previous it wasn't
        print("MOUSE ENTER");
    }

    private void OnMouseDrag()
    {
        // clicked on an object and moved the mouse
        print("MOUSE DRAG");
    }

    private void OnMouseExit()
    {
        //pointer was over the object and now is outside
        print("MOUSE EXIT");
    }

    private void OnMouseOver()
    {
        // while the pointer is over the object
        // after enter
        print("MOUSE OVER");
    }

    private void OnMouseUp()
    {
        // release button over object
        print("MOUSE UP");
    }

    private void OnMouseUpAsButton()
    {
        // behaves as a GUI button
        print("MOUSE UP AS BUTTON");
    }
}
