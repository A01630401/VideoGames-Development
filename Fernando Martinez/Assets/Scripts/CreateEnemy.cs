using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public Transform reference;
    public GameObject original;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        bool e = Input.GetKeyDown("e");

        if (e)
        {
            Instantiate(original, reference);
            Instantiate(original, reference);
            Instantiate(original, reference);
        }
    }
}
