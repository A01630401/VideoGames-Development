//same as import
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour {

    //atributes and how to expose them
    //primitive and Unity classes attributes can be exposed to the editor

    public float speed;
    public Text textito;

    private Transform t;
    private GameObject go;

    //lifecycle
    //- several methds that fit into a particular event in the life of code

    //Life of a component in Unity
    //engine works as a loop
    //the logic we do is going to fit this loop

    void Awake() {
        //run once at the very beginnig of this component's life
        //Debug.Log("AWAKE");
        print("AWAKE");
        textito.text = "This is a simple text";
        
    }

    // Start is called before the first frame update
    void Start() {
        //runs once after ALL tge awake invokations
        print("START");

        //retrieve a reference to another component in the same game object
        //t = GetComponent<Transform>();

        //retrieve a reference to another game object
        go = GameObject.Find("Capsule");
        t = go.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        //runs once per frame
        //FPS - frames per second
        //real time - 30 fps

        //this guy is important for performance
        //try to limit this for 2 things -
        //- input: responsivness
        //- motion: as smooth as possible
        //print is a non-blocking operaition

        //print("UPDATE");

        //2 main ways to deal with input
        //- polling directly to devices
        if (Input.GetKeyDown(KeyCode.A)) {
            print("DOWN");
        }

        if (Input.GetKey(KeyCode.A)) {
            print("KEY");
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            print("UP");
        }

        if(Input.GetMouseButtonDown(0)) {
            print("MOUSE DOWN");
        }
        //- polling through axis
        //a way in which the engine abstracts input

        //the result of polling an axis is a float value
        //range [-1, 1]
        float h = Input.GetAxis("Horizontal");
        float i = Input.GetAxis("Vertical");
        //print(h);

        //motion
        //several ways to move things
        // - affect position directly
        // - move through physics engine
        t.Translate(speed * h * Time.deltaTime, 0, speed * i * Time.deltaTime, Space.World);

    }

    void LateUpdate() {
        //also happen on each frame, after ALL updates are done
        //print("LATE UPDATE");
        
    }

    void FixedUpdate() {
        //runs of a set framerate
        //used if you want something to happen on a set timeframe
        //print("FIXED");
    }

    //collisions with the physics engine
    //requirements
    // - at least 2 objects (duh)
    // - both objects have a collider
    // - at least one object has a rigidbody
    // - rigidbody most be moving

    //This method is only invoked at the beggining of the collision.
    private void OnCollisionEnter(Collision collision) {
        print(collision.transform.name);
    }

    //While the objects keep touching
    private void OnCollisionStay(Collision collision) {
        print("STAY");
    }

    //When they stop touching
    private void OnCollisionExit(Collision collision) {
        print("EXIT");
    }

    //Detect trigger

    private void OnTriggerEnter(Collider other) {
        print("ENTER TRIGGER");
    }

    private void OnTriggerStay(Collider other) {
        print("STAY TRIGGER");
    }

    private void OnTriggerExit(Collider other) {
        print("EXIT TRIGGER");
    }
}
