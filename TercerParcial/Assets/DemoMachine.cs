using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMachine : MonoBehaviour
{
    private State currentState;
    private State eating, playing, sleeping;
    private Symbol getHungry, getsDark, getsBall;
    private MonoBehaviour currentBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        // language
        getHungry = new Symbol("Get Hungry");
        getsDark = new Symbol("Gets Dark");
        getsBall = new Symbol("Gets Ball");

        // states
        eating = new State("EATING", typeof(EatingBehaviour));
        playing = new State("PLAYING", typeof(PlayingBehaviour));
        sleeping = new State("SLEEPING", typeof(SleepingBehaviour));

        //transition function
        eating.AddTransition(getHungry, eating);
        eating.AddTransition(getsDark, sleeping);
        eating.AddTransition(getsBall, playing);

        playing.AddTransition(getHungry, playing);
        playing.AddTransition(getsDark, sleeping);
        playing.AddTransition(getsBall, playing);

        sleeping.AddTransition(getHungry, sleeping);
        sleeping.AddTransition(getsDark, eating);
        sleeping.AddTransition(getsBall, eating);

        // initial state
        currentState = playing;
        currentBehaviour = gameObject.AddComponent(currentState.Behaviour) as MonoBehaviour;
    }

    // Update is called once per frame
    void Update()
    {
        //print(currentState.Name);

        if (Input.GetKeyUp(KeyCode.H)) {
            currentState = currentState.ApplySymbol(getHungry);
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            currentState = currentState.ApplySymbol(getsDark);
        }

        if (Input.GetKeyUp(KeyCode.B)) {
            currentState = currentState.ApplySymbol(getsBall);
        }
    }
}
