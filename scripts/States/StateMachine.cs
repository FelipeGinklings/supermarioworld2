using Godot;
using Godot.Collections;

[GlobalClass]
public partial class StateMachine : Node {
    [Export] public State InitialState { get; set; }

    private State currentState;
    private Dictionary<string, State> states = [];

    public override void _Ready() {
        foreach (Node child in GetChildren()) {
            if (child is State state) {
                states[child.Name.ToString().ToLower()] = state;
                state.Transitioned += OnChildTransitioned;
            }
        }

        if (InitialState != null) {
            InitialState.Enter();
            currentState = InitialState;
        }
    }

    public override void _Process(double delta) {
        currentState?.Update(delta);
    }

    public override void _PhysicsProcess(double delta) {
        currentState?.PhysicsUpdate(delta);
    }

    private void OnChildTransitioned(State state, string newStateName) {
        if (state != currentState)
            return;

        if (!states.TryGetValue(newStateName.ToLower(), out State newState))
            return;

        currentState?.Exit();

        newState.Enter();
        currentState = newState;
    }
}
