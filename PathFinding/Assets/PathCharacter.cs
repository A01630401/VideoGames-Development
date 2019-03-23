using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCharacter : MonoBehaviour {
    public Waypoint start, end;

    private List<Waypoint> path;
    private int current;

    // Start is called before the first frame update
    void Start() {
        path = Pathfinding.Depthwise(start, end);
        current = 0;
    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

        // not recommendable but faster for now
        // use the other implementation!
        if (Vector3.Distance(
            transform.position,
            path[current].transform.position) < 0.1f) {
            current++;
            current %= path.Count;
        }
    }
}