using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reycaster : MonoBehaviour
{
    private Ray ray;
    public Transform observer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // raycasting
        // shooting a ray in (or into) the world
        // checking where it hit (if it did)

        // get a ray!
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            print(hit.transform);
            print(hit.point );
            observer.LookAt(hit.point);
        }
        else
        {
            print("MISS");
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(ray);
    }
}
