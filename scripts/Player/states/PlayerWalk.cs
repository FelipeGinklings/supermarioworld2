using Godot;


public partial class PlayerWalk : PlayerState {
    public override void Enter() {
        player.animationPlayer.Play("walk");
    }
    public void Flip() {
        if (player.Velocity.X < 0) {
            player.animationPlayer.FlipH = true;
        } else if (player.Velocity.X > 0) {
            player.animationPlayer.FlipH = false;
        }
    }

    public override void PhysicsUpdate(double delta) {
        var inputDirectionX = Input.GetAxis("move_left", "move_right");
        player.Velocity = new Vector2(player.speed * inputDirectionX, player.Velocity.Y + player.GetGravity().Y * (float)delta);
        player.MoveAndSlide();

        if (!player.IsOnFloor()) {
            EmitSignal(SignalName.Transitioned, this, FALL);
        } else if (Input.IsActionJustPressed("ui_accept")) {
            EmitSignal(SignalName.Transitioned, this, JUMP);
        } else if (Mathf.IsEqualApprox(inputDirectionX, 0.0f)) {
            EmitSignal(SignalName.Transitioned, this, IDLE);
        }
    }


}
