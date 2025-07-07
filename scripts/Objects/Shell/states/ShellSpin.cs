using Godot;
using System;

public partial class ShellSpin : ShellState {

    Player player;
    private bool isStomping = false;
    public override void Enter() {
        // Play the spin animation
        // GD.Print("ShellSpin: Enter");
        shell.animationShell.Play(shell.selectedColor + "-spin");
        shell.ApplyImpulse(direction == WalkDirections.Left ? Vector2.Left * shell.speed * shell.initialImpulse : Vector2.Right * shell.speed * shell.initialImpulse);
        isStomping = false;
    }

    public void GoToIdle(Area2D area) {
        GD.Print("ShellSpin: GoToIdle");
        isStomping = true;
        if (area != null) {
            player = area.GetParent() as Player;
        }
    }

    public void Kill(Node _) {
        // Implement logic for killing the shell if needed
        // This could involve removing the shell from the scene or changing its state
        // // GD.Print("Shell killed " + body.Name);
        // EmitSignal(State.SignalName.Transitioned, this, IDLE);
    }

    public void GoToLeft(Node2D _) {
        // GD.Print("ShellSpin: GoToLeft from Body - ");
        direction = WalkDirections.Left;
    }

    public void GoToRight(Node2D _) {
        // GD.Print("ShellSpin: GoToRight from Body - ");
        direction = WalkDirections.Right;
    }

    public override void PhysicsUpdate(double delta) {
        if (isStomping) {
            if (player != null) {
                float jumpForce = -200; // Adjust jump strength as needed
                float horizontalForce = direction == WalkDirections.Right ? -800.0f : 800.0f; // Opposite to shell direction
                player.Velocity = new Vector2(horizontalForce, jumpForce);
                player.MoveAndSlide();
            }
            EmitSignal(State.SignalName.Transitioned, this, IDLE);
            return; // Exit early if stomping
        }
        shell.LinearVelocity = new Vector2(shell.speed, shell.LinearVelocity.Y); // Move right with speed 200
        shell.LinearVelocity = new Vector2(shell.speed * (direction == WalkDirections.Right ? 1 : -1), shell.LinearVelocity.Y); // Set direction based on the current state
        shell.MoveAndCollide(shell.LinearVelocity * (float)delta);
    }


    public override void Exit() {
        // Stop the spin animation
        // GD.Print("ShellSpin: Exit");
        isStomping = false;
        shell.animationShell.Stop();
    }
}
