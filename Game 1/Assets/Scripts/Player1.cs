using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public Text score;
    public int speed;
    public EnemyScript enemy;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        print(enemy.speed);
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        transform.Translate(5 * x * Time.deltaTime, 0, 5 * z * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.name);
        if (other.transform.name == "Goal")
        {
            int score1 = int.Parse(score.text) + 50;
            score.text = "" + score1;
            enemy.speed += 5;
            transform.SetPositionAndRotation(position, transform.rotation);
            
        }
    }
}
