using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State
{
    private string name;
    private Dictionary<Symbol, State> transition;
    private Type behaviour;

    public State(string name, Type behaviour) {
        this.name = name;
        this.behaviour = behaviour;
        transition = new Dictionary<Symbol, State>();
    }

    public Type Behaviour {
        get {
            return behaviour;
        }
    }

    public string Name {
        get {
            return name;
        }
    }

    public Dictionary<Symbol, State> Transition {
        get {
            return transition;
        }
    }

    public void AddTransition(Symbol symbol, State state) {
        transition.Add(symbol, state);
    }

    public State ApplySymbol(Symbol symbol) {

        if (!transition.ContainsKey(symbol)) {
            return this;
        }

        return transition[symbol];
    }
}
