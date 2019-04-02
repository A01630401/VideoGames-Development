using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    NavMeshAgent agent;

    public Waypoint start, end;

    private List<Waypoint> path;
    private int current;

    public float threshold;

    public Material mat;

    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        path = Pathfinding.Depthwise(start, end);
        current = 0;

        StartCoroutine("Patrol");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayito, out hit)) {
                agent.destination = hit.point;
            }

            StopCoroutine("Patrol");
            flag = false;
            print("Not Patrol");
            GetComponent<MeshRenderer>().material = null;
        }
        else {
            agent.destination =  path[current].transform.position;
            agent.transform.LookAt(path[current].transform);
            //agent.transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

            float d = Vector3.Distance(transform.position, path[current].transform.position);

            if (d < threshold) {
                current++;
                current %= path.Count;
            }

            if (!flag)
                StartCoroutine("Patrol");

        }

        
        //if (Vector3.Distance(transform.position, path[current].transform.position) < 0.1f) {
          //  current++;
            //current %= path.Count;
        //}
    }

    IEnumerator Patrol() {
        while (true) {
            GetComponent<MeshRenderer>().material = mat;
            yield return new WaitForSeconds(1);
            print("Patrol");
            flag = true;
        }
    }
}
