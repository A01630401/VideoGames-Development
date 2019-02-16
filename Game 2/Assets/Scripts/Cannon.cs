using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private float lastJ;
    private float rot;
    public GameObject original;
    public Transform reference;
    public Transform reference2;
    public GameObject cannon2;
    // Start is called before the first frame update
    void Start()
    {
        lastJ = 0;
        rot = gameObject.transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        rot -= Input.GetAxis("Vertical");
        float j = Input.GetAxis("Jump");
        if (!Turn.turn)
        {
            transform.eulerAngles = new Vector3(rot, 0, 0);
            if (lastJ == 0 && j == 1)
            {
                Instantiate(original, reference.position, reference.rotation);
            }

            lastJ = j;
        }
        else
        {
            cannon2.transform.eulerAngles = new Vector3(rot, 0, 0);
            if (lastJ == 0 && j == 1)
            {
                Instantiate(original, reference2.position, reference2.rotation);
            }

            lastJ = j;
        }
        

        
    }
}
