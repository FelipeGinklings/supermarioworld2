using Godot;


public partial class PlayerIdle : PlayerState {
    public override void Enter() {
        player.Velocity = new Vector2(0.0f, player.Velocity.Y);
        player.animationPlayer.Play(IDLE);
    }

    public override void PhysicsUpdate(double delta) {
        var velocity = player.Velocity;
        var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        velocity.Y += player.GetGravity().Y * (float)delta;
        player.Velocity = velocity;
        player.MoveAndSlide();

        if (!player.IsOnFloor()) {
            EmitSignal(SignalName.Transitioned, this, FALL);
        } else if (Input.IsActionJustPressed("ui_accept")) {
            EmitSignal(SignalName.Transitioned, this, JUMP);
        } else if (direction.X != 0) {
            EmitSignal(SignalName.Transitioned, this, WALK);
        } else if (direction.Y > 0) {
            player.animationPlayer.Play(LOOK_UP);
        } else if (direction.Y < 0) {
            player.animationPlayer.Play(DUCK);
        }
    }


}
