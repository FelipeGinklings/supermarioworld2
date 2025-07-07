using Godot;
using System;

public partial class Climbing : PlayerState {

    public override void Enter() {
        player.animationPlayer.Play(CLIMB);
        player.SetPhysicsProcess(true);
        player.Velocity = Vector2.Zero;
    }

    public override void PhysicsUpdate(double delta) {
        float inputDirectionY = Input.GetAxis(INPUT_UP, INPUT_DOWN);
        player.Velocity = new Vector2(player.Velocity.X, player.speed * inputDirectionY + player.GetGravity().Y * (float)delta);
        player.MoveAndSlide();

        if (player.IsOnFloor()) {
            EmitSignal(State.SignalName.Transitioned, this, IDLE);
        } else if (Input.IsActionJustPressed(INPUT_JUMP)) {
            EmitSignal(State.SignalName.Transitioned, this, JUMP);
        }
    }
}
