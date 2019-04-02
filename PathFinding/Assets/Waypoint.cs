using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public Waypoint[] neighbors;
    public List<Waypoint> history;
    public float g, h;

    // property
    // refined mechanism that does the same (and more) than the accessor methods
    public float F {
        get {
            return g + h;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);

        Gizmos.color = Color.green;
        foreach(Waypoint current in neighbors)
        {
            Gizmos.DrawLine(transform.position, current.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
