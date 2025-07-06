using Godot;
using System;

public partial class ShellIdle : ShellState {

    public override void Enter() {
        shell.LinearVelocity = Vector2.Zero;
        shell.animationShell.Play(shell.selectedColor + "-idle");
    }

    public void GoToLeft(Node2D _body) {
        direction = WalkDirections.Left;
        EmitSignal(State.SignalName.Transitioned, this, SPIN);
    }

    public void GoToRight(Node2D _body) {
        direction = WalkDirections.Right;
        EmitSignal(State.SignalName.Transitioned, this, SPIN);
    }

    public override void Exit() {
        shell.animationShell.Stop();
    }
}
