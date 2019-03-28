using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] points;
    private int i = 0;
    private float threshold = 0.1f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(points[i]);
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, 3 * Time.deltaTime);
        float d = Vector3.Distance(transform.position, points[i].transform.position);

        if (d < threshold) {
            i++;
            i %= points.Length;
        }
    }
}
