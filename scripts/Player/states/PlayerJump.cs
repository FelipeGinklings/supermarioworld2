using Godot;

public partial class PlayerJump : PlayerState {
    public override void Enter() {
        player.Velocity = new Vector2(player.Velocity.X, player.maxJump);
        player.animationPlayer.Play(JUMP);
    }

    public override void PhysicsUpdate(double delta) {
        float inputDirectionX = Input.GetAxis(INPUT_LEFT, INPUT_RIGHT);
        Vector2 velocity = player.Velocity;
        velocity.X = player.speed * inputDirectionX;
        velocity.Y += player.GetGravity().Y * (float)delta;
        player.Velocity = velocity;
        player.MoveAndSlide();

        if (player.Velocity.Y >= 0) {
            if (player.IsOnStairs) {
                EmitSignal(State.SignalName.Transitioned, this, CLIMB);
            }
            EmitSignal(State.SignalName.Transitioned, this, FALL);
        }
    }
}