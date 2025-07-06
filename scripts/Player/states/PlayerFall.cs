using Godot;

public partial class PlayerFall : PlayerState {
    public override void Enter() {
        player.animationPlayer.Play(FALL);
    }

    public override void PhysicsUpdate(double delta) {
        float inputDirectionX = Input.GetAxis(INPUT_LEFT, INPUT_RIGHT);
        player.Velocity = new Vector2(player.speed * inputDirectionX, player.Velocity.Y + player.GetGravity().Y * (float)delta);
        if (player.ReachedTheEnd) {
            player.Velocity = new Vector2(0.0f, player.Velocity.Y + player.GetGravity().Y * (float)delta);
            EmitSignal(State.SignalName.Transitioned, this, VICTORY);
            return;
        }
        player.MoveAndSlide();

        if (player.IsOnFloor()) {
            if (Mathf.IsEqualApprox(inputDirectionX, 0.0f)) {
                EmitSignal(State.SignalName.Transitioned, this, IDLE);
            } else {
                EmitSignal(State.SignalName.Transitioned, this, WALK);
            }
        }
    }
}