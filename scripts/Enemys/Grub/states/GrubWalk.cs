using Godot;
using System;

public partial class GrubWalk : GrubState {
    [Export] private RayCast2D raycast;
    private WalkDirections direction = WalkDirections.Left;

    private bool gotHit = false;
    private bool hasJumped = false;

    public override void Enter() {
        grub.animationGrub.Play(grub.selectedColor + "-" + WALK);
        gotHit = false;
        hasJumped = false;
    }

    public void GotHit(Area2D _) {
        gotHit = true;
    }

    public override void PhysicsUpdate(double delta) {
        // Check if raycast is hitting something
        if (raycast.IsColliding() && !hasJumped) {
            var collider = raycast.GetCollider();
            if (collider is Shell shell) {
                hasJumped = true;
                float jumpForce = -120.0f;
                float horizontalForce = direction == WalkDirections.Right ? 80.0f : -80.0f;
                grub.Velocity = new Vector2(horizontalForce, jumpForce);
                GetTree().CreateTimer(0.3f).Timeout += () => {
                    shell.QueueFree();
                    grub.SetPhysicsProcess(false);
                    EmitSignal(State.SignalName.Transitioned, this, MERGE);
                };
            }
        }
        if (hasJumped) {
            grub.Velocity = new Vector2(grub.Velocity.X, grub.Velocity.Y + grub.GetGravity().Y * (float)delta);
            grub.MoveAndSlide();
            return;
        }
        if (gotHit) {
            grub.SetPhysicsProcess(false);
            EmitSignal(State.SignalName.Transitioned, this, DEATH);
            return;
        }
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
        grub.animationGrub.FlipH = direction == WalkDirections.Right; ;
    }
}
