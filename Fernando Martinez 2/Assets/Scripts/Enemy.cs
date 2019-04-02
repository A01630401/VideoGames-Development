using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] points;
    private int i = 0;
    private float threshold = 0.1f;

    public Waypoint start, end;
    private List<Waypoint> path;
    private int current;
    // Start is called before the first frame update
    void Start()
    {
        path = Depthwise(start, end);
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print(variables.enterWaypoint);
        if (variables.enterWaypoint) {
            print(path);
            transform.LookAt(path[current].transform);
            transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

            float distance = Vector3.Distance(transform.position, path[i].transform.position);

            if (distance < threshold) {
                current++;
                current %= path.Count;
            }
        }
        else {
            transform.LookAt(points[i]);
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, 3 * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, points[i].transform.position);

            if (distance < threshold) {
                i++;
                i %= points.Length;
            }
        }
        
    }

    public static List<Waypoint> Depthwise(Waypoint start, Waypoint end) {
        List<Waypoint> visited = new List<Waypoint>();
        Stack<Waypoint> work = new Stack<Waypoint>();
        visited.Add(start);
        work.Push(start);
        start.history = new List<Waypoint>();
        while (work.Count > 0) {
            Waypoint actual = work.Pop();
            if (actual == end) {
                actual.history.Add(actual);
                return actual.history;
            }
            else {
                for (int i = 0; i < actual.vecinos.Length; i++) {
                    Waypoint currentNeighbor = actual.vecinos[i];
                    if (visited.Contains(currentNeighbor) == false) {
                        visited.Add(currentNeighbor);
                        currentNeighbor.history = new List<Waypoint>(actual.history);
                        currentNeighbor.history.Add(actual);
                        work.Push(currentNeighbor);
                    }
                }
            }
        }

        return null;
    }
}
