using Godot;
using System;

public partial class ShellSpin : ShellState {
    public override void Enter() {
        // Play the spin animation
        GD.Print("ShellSpin: Enter");
        shell.animationShell.Play(shell.selectedColor + "-spin");
        shell.ApplyImpulse(direction == WalkDirections.Left ? Vector2.Left * shell.speed * shell.initialImpulse : Vector2.Right * shell.speed * shell.initialImpulse);
    }

    public void GoToIdle(Area2D _) {
        GD.Print("ShellSpin: GoToIdle");
        EmitSignal(State.SignalName.Transitioned, this, IDLE);
    }

    public void Kill(Node _) {
        // Implement logic for killing the shell if needed
        // This could involve removing the shell from the scene or changing its state
        // GD.Print("Shell killed " + body.Name);
        // EmitSignal(State.SignalName.Transitioned, this, IDLE);
    }


    public void GoToLeft(Node2D _) {
        // GD.Print("ShellSpin: GoToLeft from Body - " + body.Name);
        direction = WalkDirections.Left;
    }

    public void GoToRight(Node2D _) {
        // GD.Print("ShellSpin: GoToRight from Body - " + body.Name);
        direction = WalkDirections.Right;
    }

    public override void PhysicsUpdate(double delta) {
        shell.LinearVelocity = new Vector2(shell.speed, shell.LinearVelocity.Y); // Move right with speed 200
        shell.LinearVelocity = new Vector2(shell.speed * (direction == WalkDirections.Right ? 1 : -1), shell.LinearVelocity.Y); // Set direction based on the current state
        shell.MoveAndCollide(shell.LinearVelocity * (float)delta);
    }


    public override void Exit() {
        // Stop the spin animation
        GD.Print("ShellSpin: Exit");
        shell.animationShell.Stop();
    }
}
