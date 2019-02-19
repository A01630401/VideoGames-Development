using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject original;
    public Canvas text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q = new Quaternion(45, 0, 0, 0);
        float h = Input.GetAxis("Horizontal");
        float j = Input.GetAxis("Vertical");

        bool a = Input.GetButtonDown("Jump");
        if (a)
        {
            
            Instantiate(original, gameObject.transform);
            print("shooting");
        }

        transform.Translate(h * 10 * Time.deltaTime, j * 10 * Time.deltaTime, 0);
        
    }
}
