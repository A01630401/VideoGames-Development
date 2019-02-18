using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour
{
    public GameObject original;
    public Transform reference;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 positions;
        for (int l = 1; l < 20; l++)
        {
            positions = new Vector3(reference.position.x + l, reference.position.y, reference.position.z);
            Instantiate(original, positions, reference.rotation);
        }
        for (int i = 0; i<20; i++)
        {
            for(int j = 1; j<20; j++)
            {
                positions = new Vector3(reference.position.x + i, reference.position.y, reference.position.z + j);
                Instantiate(original, positions, reference.rotation);
            }
        }

        for(int o = 0; o < 500; o++)
        {
            int l = 0;
            l++;
            if(l > 100)
            {
                l = 0;
            }
            int rand = (int) Random.Range(1, 20);
            int rand2 = (int)Random.Range(2, 17);
            positions = new Vector3(reference.position.x + rand, reference.position.y + l, reference.position.z + rand2);
            Instantiate(original, positions, reference.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
