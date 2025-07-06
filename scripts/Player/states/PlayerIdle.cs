using Godot;


public partial class PlayerIdle : PlayerState {
    public override void Enter() {
        player.Velocity = new Vector2(0.0f, player.Velocity.Y);
        player.animationPlayer.Play(IDLE);
    }

    public override void PhysicsUpdate(double delta) {
        if (player.ReachedTheEnd) {
            EmitSignal(State.SignalName.Transitioned, this, VICTORY);
            return;
        }
        var velocity = player.Velocity;
        var direction = Input.GetVector(INPUT_LEFT, INPUT_RIGHT, INPUT_UP, INPUT_DOWN);
        velocity.Y += player.GetGravity().Y * (float)delta;
        player.Velocity = velocity;
        player.MoveAndSlide();
        if (!player.IsOnFloor()) {
            EmitSignal(State.SignalName.Transitioned, this, FALL);
        } else if (Input.IsActionJustPressed(INPUT_JUMP)) {
            EmitSignal(State.SignalName.Transitioned, this, JUMP);
        } else if (direction.X != 0) {
            EmitSignal(State.SignalName.Transitioned, this, WALK);
        } else if (direction.Y < 0) {
            player.animationPlayer.Play(LOOK_UP);
        } else if (direction.Y > 0) {
            player.animationPlayer.Play(DUCK);
        } else {
            player.animationPlayer.Play(IDLE);
        }
    }


}
