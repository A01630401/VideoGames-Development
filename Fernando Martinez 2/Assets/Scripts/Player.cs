using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject original;
    public Transform reference;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 y = Input.mousePosition;

        transform.rotation = Quaternion.Euler(0, -y.y, 0);

        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        transform.Translate(5 * x * Time.deltaTime, 0, 5 * z * Time.deltaTime, Space.World);


    }

    IEnumerator Shoot() {
        while (true) {
            Instantiate(original, reference.position, reference.rotation);
            yield return new WaitForSeconds(1);
        }
    }
}
