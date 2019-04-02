using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

    // 3 different algorithms with the same purpose -
    // - find a path in a network (graph)

    // return a list of waypoints and recieve 2 waypoints
    public static List<Waypoint> Breadthwise(Waypoint start, Waypoint end) {
        List<Waypoint> visited = new List<Waypoint>();
        Queue<Waypoint> work = new Queue<Waypoint>();

        visited.Add(start);
        work.Enqueue(start);
        start.history = new List<Waypoint>();

        while(work.Count > 0) {

            Waypoint current = work.Dequeue();
            if(current == end) {
                // found
                current.history.Add(current);
                return current.history;
            }
            else {
                // not found
                for(int i = 0; i < current.neighbors.Length; i++) {
                    Waypoint currentNeighbor = current.neighbors[i];
                    if (!visited.Contains(currentNeighbor)) {

                        // add to visited list to avoid loops in the future
                        visited.Add(currentNeighbor);

                        // add to queue to process this node later
                        work.Enqueue(currentNeighbor);

                        // set the history the same as the parent
                        currentNeighbor.history = new List<Waypoint>(current.history);

                        // add the parent to the history
                        currentNeighbor.history.Add(current);
                    }
                }
            }
        }

        return null;
    }

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
                for(int i = 0; i < current.neighbors.Length; i++) {
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

    public static List<Waypoint> AStar(Waypoint start, Waypoint end) {

        List<Waypoint> visited, work;
        visited = new List<Waypoint>();
        work = new List<Waypoint>();

        start.history = new List<Waypoint>();
        visited.Add(start);
        work.Add(start);
        start.g = 0;
        start.h = 0;

        while(work.Count > 0) {

            // the next one to process
            Waypoint actual = work[0];
            for(int i = 1; i < work.Count; i++) {
                if(work[i].F < actual.F) {
                    actual = work[i];
                }
            }

            work.Remove(actual);

            // we could check if its the target node
            // bur we're going to do it later
            foreach (Waypoint currentNeighbor in actual.neighbors) {
                if (!visited.Contains(currentNeighbor)) {
                    // check if its the target
                    if(currentNeighbor == end) {
                        List<Waypoint> result = actual.history;
                        result.Add(currentNeighbor);
                        return result;
                    }

                    // calculate g and h for each neighbor
                    currentNeighbor.g = actual.g + Vector3.Distance(actual.transform.position, currentNeighbor.transform.position);

                    currentNeighbor.h = Vector3.Distance(currentNeighbor.transform.position, end.transform.position);

                    currentNeighbor.history = new List<Waypoint>(actual.history);
                    currentNeighbor.history.Add(actual);

                    work.Add(currentNeighbor);
                    work.Add(currentNeighbor);
                }
            }

        }

        return null;
    }
}
