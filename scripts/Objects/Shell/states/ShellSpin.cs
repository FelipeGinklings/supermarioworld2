using Godot;
using System;

public partial class ShellRun : ShellState {

    public override void Enter() {
        // Play the run animation
        shell.animationShell.Play(shell.selectedColor + "-run");
    }

    public override void Exit() {
        // Stop the run animation
        shell.animationShell.Stop();
    }

    public override void PhysicsUpdate(double delta) {
        // Move the shell forward at its speed
        shell.LinearVelocity = new Vector2(shell.speed, 0);
    }
}
