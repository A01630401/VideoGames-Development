using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint[] vecinos;
    public List<Waypoint> history;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        variables.enterWaypoint = true;
    }

    private void OnTriggerExit(Collider other) {
        variables.enterWaypoint = false;
    }
}
