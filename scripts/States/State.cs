using Godot;
using System;

[GlobalClass]
public partial class State : Node {
    [Signal]
    public delegate void TransitionedEventHandler(State state, string newStateName);

    public virtual void Enter() {
        // Override in derived classes
    }

    public virtual void Exit() {
        // Override in derived classes
    }

    public virtual void Update(double delta) {
        // Override in derived classes
    }

    public virtual void PhysicsUpdate(double delta) {
        // Override in derived classes
    }
}
