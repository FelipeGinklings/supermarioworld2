using Godot;
using System;

public partial class GrubWalk : GrubState {
    [Export] private RayCast2D raycast;
    private WalkDirections direction = WalkDirections.Left;

    private bool gotHit = false;

    public override void Enter() {
        grub.animationGrub.Play(grub.selectedColor + "-" + WALK);
    }

    public override void Update(double delta) {
        if (gotHit) {
            grub.SetPhysicsProcess(false);
            EmitSignal(State.SignalName.Transitioned, this, DEATH);
            return;
        }
    }

    public override void PhysicsUpdate(double delta) {
        // Set velocity based on current direction
        if (direction == WalkDirections.Left) {
            grub.Velocity = new Vector2(-grub.speed, grub.Velocity.Y);
        } else {
            grub.Velocity = new Vector2(grub.speed, grub.Velocity.Y);
        }

        // Apply gravity
        grub.Velocity = new Vector2(grub.Velocity.X, grub.Velocity.Y + grub.GetGravity().Y * (float)delta);

        // Move and check for collisions
        grub.MoveAndSlide();

        if (grub.IsOnWall()) {
            ToggleKoopaDirection();
        }
    }

    private void ToggleKoopaDirection() {
        direction = direction == WalkDirections.Left ? WalkDirections.Right : WalkDirections.Left;
        grub.animationGrub.Play(grub.selectedColor + "-" + WALK);
        grub.animationGrub.FlipH = direction == WalkDirections.Left; ;
    }
}
