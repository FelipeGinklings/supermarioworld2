using Godot;

public partial class PlayerFall : PlayerState {
    public override void Enter() {
        player.animationPlayer.Play(FALL);
    }

    public override void PhysicsUpdate(double delta) {
        float inputDirectionX = Input.GetAxis("move_left", "move_right");
        player.Velocity = new Vector2(player.speed * inputDirectionX, player.Velocity.Y + player.GetGravity().Y * (float)delta);
        player.MoveAndSlide();

        if (player.IsOnFloor()) {
            if (Mathf.IsEqualApprox(inputDirectionX, 0.0f)) {
                EmitSignal(SignalName.Transitioned, IDLE);
            } else {
                EmitSignal(SignalName.Transitioned, WALK);
            }
        }
    }
}