using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Turn.turn)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 18);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -18);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        }
    }
}
