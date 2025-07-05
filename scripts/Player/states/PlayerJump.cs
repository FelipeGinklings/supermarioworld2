using Godot;

public partial class PlayerJump : PlayerState {
    public override void Enter() {
        player.Velocity = new Vector2(player.Velocity.X, -player.jumpHeight);
        player.animationPlayer.Play(JUMP);
    }

    public override void PhysicsUpdate(double delta) {
        float inputDirectionX = Input.GetAxis("move_left", "move_right");
        Vector2 velocity = player.Velocity;
        velocity.X = player.speed * inputDirectionX;
        velocity.Y += player.GetGravity().Y * (float)delta;
        player.Velocity = velocity;
        player.MoveAndSlide();

        if (player.Velocity.Y >= 0) {
            EmitSignal(SignalName.Transitioned, JUMP);
        }
    }
}