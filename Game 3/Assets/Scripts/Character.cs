using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Ray ray;
    private CharacterController controller;
    public GameObject original;
    public Transform reference;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * 150 * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * 150 * Time.deltaTime;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.right * mouseY * -1);
        transform.Rotate(Vector3.up * mouseX);
        float horizontalInput = Input.GetAxis("Horizontal") * 200 * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * 200 * Time.deltaTime;

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        controller.SimpleMove(forwardMovement + rightMovement);
        //transform.forward;
        /*ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            transform.LookAt(hit.point);
        }*/

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(original, reference.position, reference.rotation);
        }
    }

    private void OnMouseUpAsButton() {
        
    }
}
