using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // stalker
    public Waypoint[] path;
    public float threshold;

    private int current;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 2, Space.World);
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
            yield return new WaitForSeconds(0.2f);
        }
    }
}
