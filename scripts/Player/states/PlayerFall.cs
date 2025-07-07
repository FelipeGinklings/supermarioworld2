using Godot;

public partial class PlayerFall : PlayerState {
    public bool isStomping = false;
    public float remainingTime = 0; // Time in seconds to allow jump input
    public override void Enter() {
        player.animationPlayer.Play(FALL);
        isStomping = false;
        remainingTime = 0.0f; // Reset remaining time when entering fall state
    }

    public void Stomp(Area2D area) {
        // GD.Print("PlayerFall: Stomped on " + area.Name);
        // Check if we hit a Shell's Top area
        if (area.Name == "Top" && area.GetParent() is Shell) {
            isStomping = true;
            remainingTime = 0.11f;
        }
    }

    public override void PhysicsUpdate(double delta) {
        if (player.ReachedTheEnd) {
            player.Velocity = new Vector2(0.0f, player.Velocity.Y + player.GetGravity().Y * (float)delta);
            EmitSignal(State.SignalName.Transitioned, this, VICTORY);
            return;
        }
        if (isStomping && remainingTime > 0 && Input.IsActionJustPressed(INPUT_JUMP)) {
            player.animationPlayer.Play(JUMP);
            player.Velocity = new Vector2(player.Velocity.X, player.maxJump); // Bounce with 60% of normal jump force
            isStomping = false; // Reset stomping state after jumping
        } else if (isStomping && remainingTime <= 0) {
            player.animationPlayer.Play(JUMP);
            player.Velocity = new Vector2(player.Velocity.X, player.maxJump * 0.6f); // Bounce with 30% of normal jump force
            isStomping = false; // Reset stomping state after jumping
        }
        remainingTime -= (float)delta;
        player.animationPlayer.Play(FALL);
        float inputDirectionX = Input.GetAxis(INPUT_LEFT, INPUT_RIGHT);
        player.Velocity = new Vector2(player.speed * inputDirectionX, player.Velocity.Y + player.GetGravity().Y * (float)delta);
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