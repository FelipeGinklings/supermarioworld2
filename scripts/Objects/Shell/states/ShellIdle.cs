using Godot;
using System;

public partial class ShellIdle : ShellState {

    public override void Enter() {
        shell.LinearVelocity = Vector2.Zero;
        shell.animationShell.Play(shell.selectedColor + "-idle");
    }

    public override void Exit() {
        // Stop the idle animation
        shell.animationShell.Stop();
    }

    public override void PhysicsUpdate(double delta) {
    }
}
