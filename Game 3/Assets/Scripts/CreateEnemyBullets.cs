using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyBullets : MonoBehaviour
{
    public GameObject original;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchBullet", 0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchBullet() {

        Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 1, 10);

        Instantiate(original, position, transform.rotation);
    }
}
