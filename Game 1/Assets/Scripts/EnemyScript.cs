using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private int flag = 1;
    public Text score;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * flag, 0, 0, Space.World);
        print(speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        flag *= -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player 1") { 
            int score1 = int.Parse(score.text) - 5;
            score.text = "" + score1;
        }
    }
}
