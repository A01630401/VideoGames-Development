using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public static List<Waypoint> Depthwise(Waypoint start, Waypoint end) {
        List<Waypoint> visited = new List<Waypoint>();
        Stack<Waypoint> work = new Stack<Waypoint>();

        visited.Add(start);
        work.Push(start);

        start.history = new List<Waypoint>();

        while (work.Count > 0) {
            Waypoint current = work.Pop();
            if (current == end) {
                current.history.Add(current);
                return current.history;
            }
            else {
                for (int i = 0; i < current.neighbors.Length; i++) {
                    Waypoint currentNeighbor = current.neighbors[i];
                    if (!visited.Contains(currentNeighbor)) {
                        visited.Add(currentNeighbor);
                        work.Push(currentNeighbor);

                        currentNeighbor.history = new List<Waypoint>(current.history);
                        currentNeighbor.history.Add(current);
                    }
                }
            }
        }

        return null;
    }
}
