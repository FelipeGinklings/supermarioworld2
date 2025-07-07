using Godot;


public partial class KoopaWalk : KoopaState {
    private WalkDirections direction = WalkDirections.Left;
    public override void Enter() {
        koopa.animationKoopa.Play(koopa.selectedColor + "-" + WALK);
    }

    public override void PhysicsUpdate(double delta) {
        // Set velocity based on current direction
        if (direction == WalkDirections.Left) {
            koopa.Velocity = new Vector2(-koopa.speed, koopa.Velocity.Y);
        } else {
            koopa.Velocity = new Vector2(koopa.speed, koopa.Velocity.Y);
        }

        // Apply gravity
        koopa.Velocity = new Vector2(koopa.Velocity.X, koopa.Velocity.Y + koopa.GetGravity().Y * (float)delta);

        // Move and check for collisions
        koopa.MoveAndSlide();

        if (koopa.IsOnWall()) {
            ToggleKoopaDirection();
        }
    }

    private void ToggleKoopaDirection() {
        koopa.animationKoopa.Stop();
        var shouldFlip = direction == WalkDirections.Left;
        if (shouldFlip) {
            koopa.animationKoopa.Play(koopa.selectedColor + TURN + RIGHT);
            direction = WalkDirections.Right;
        } else {
            koopa.animationKoopa.Play(koopa.selectedColor + TURN + LEFT);
            direction = WalkDirections.Left;
        }
        koopa.animationKoopa.Play(koopa.selectedColor + "-" + WALK);
        koopa.animationKoopa.FlipH = shouldFlip;
    }

    public void GotHit(Area2D _) {
        GD.Print("KoopaWalk: GotHit");
        koopa.SetPhysicsProcess(false);
        EmitSignal(State.SignalName.Transitioned, this, SEPARATE);
    }
}
