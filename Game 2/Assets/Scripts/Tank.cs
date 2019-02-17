using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private bool turn;
    public GameObject tank2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        turn = Turn.turn;
        float h = Input.GetAxis("Horizontal");
        if (!turn)
            transform.Translate(h * 10 * Time.deltaTime, 0, 0, Space.World);
        else
            tank2.transform.Translate((-1) * h * 10 * Time.deltaTime, 0, 0, Space.World);
    }
}
