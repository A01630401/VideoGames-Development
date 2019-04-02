using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour {

    public Waypoint start, end;

    // Start is called before the first frame update
    void Start() {
        //List<Waypoint> path = Pathfinding.Breadthwise(start, end);
        //List<Waypoint> path = Pathfinding.Depthwise(start, end);
        List<Waypoint> path = Pathfinding.AStar(start, end);
        foreach (Waypoint w in path) {
            Debug.Log(w.transform.name);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}