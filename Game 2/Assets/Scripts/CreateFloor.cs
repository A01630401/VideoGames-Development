using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour
{
    public GameObject original;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 positions;
        for (int i = 0; i<20; i++)
        {
            for(int j = 0; j<20; j++)
            {
                positions = new Vector3(original.transform.position.x + i, original.transform.position.y, original.transform.position.z + j);
                Instantiate(original, positions, original.transform.rotation);
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
            int rand2 = (int)Random.Range(2, 18);
            positions = new Vector3(original.transform.position.x + rand, original.transform.position.y + l, original.transform.position.z + rand2);
            Instantiate(original, positions, original.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
