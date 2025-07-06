using Godot;
using System;

public partial class ShellSpin : ShellState {
    public override void Enter() {
        // Play the spin animation
        shell.animationShell.Play(shell.selectedColor + "-spin");
    }

    public void StopShell(RigidBody2D area_rid, Area2D area, int area_shape_index, int local_shape_index) {
        EmitSignal(State.SignalName.Transitioned, this, IDLE);
    }

    public void Kill(Node body) {
        // Implement logic for killing the shell if needed
        // This could involve removing the shell from the scene or changing its state
        GD.Print("Shell killed " + body.Name);
        EmitSignal(State.SignalName.Transitioned, this, IDLE);
    }

    public override void PhysicsUpdate(double delta) {
        // Apply a constant force to keep the shell spinning
        Vector2 force = direction == WalkDirections.Left ? Vector2.Left : Vector2.Right;
        shell.ApplyForce(force * shell.speed * 50);
    }


    public override void Exit() {
        // Stop the spin animation
        shell.animationShell.Stop();
    }
}
