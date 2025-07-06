using Godot;


public partial class PlayerWalk : PlayerState {
    public override void Enter() {
        player.animationPlayer.Play(WALK);
    }
    public void Flip() {
        if (player.Velocity.X > 0) {
            player.animationPlayer.FlipH = true;
        } else if (player.Velocity.X < 0) {
            player.animationPlayer.FlipH = false;
        }
    }

    public override void PhysicsUpdate(double delta) {
        if (player.ReachedTheEnd) {
            EmitSignal(State.SignalName.Transitioned, this, VICTORY);
            return;
        }
        var inputDirectionX = Input.GetAxis(INPUT_LEFT, INPUT_RIGHT);
        player.Velocity = new Vector2(player.speed * inputDirectionX, player.Velocity.Y + player.GetGravity().Y * (float)delta);
        Flip();
        player.MoveAndSlide();

        if (!player.IsOnFloor()) {
            EmitSignal(State.SignalName.Transitioned, this, FALL);
        } else if (Input.IsActionJustPressed(INPUT_JUMP)) {
            EmitSignal(State.SignalName.Transitioned, this, JUMP);
        } else if (Mathf.IsEqualApprox(inputDirectionX, 0.0f)) {
            EmitSignal(State.SignalName.Transitioned, this, IDLE);
        }
    }


}
