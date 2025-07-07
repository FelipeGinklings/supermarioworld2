using Godot;
using System;

public partial class PlayerClimb : PlayerState {

    public override void Enter() {
        player.SetPhysicsProcess(true);
        player.Velocity = Vector2.Zero;
    }

    public void ExitedStairs(Area2D area) {
        GD.Print("PlayerClimb: ExitedStair");
        // EmitSignal(State.SignalName.Transitioned, this, IDLE);
    }

    public override void PhysicsUpdate(double delta) {
        float inputDirectionY = Input.GetAxis(INPUT_UP, INPUT_DOWN);
        float inputDirectionX = Input.GetAxis(INPUT_LEFT, INPUT_RIGHT);
        player.Velocity = new Vector2(player.speed * inputDirectionX, player.speed * inputDirectionY);
        player.MoveAndSlide();

        if (player.Velocity != Vector2.Zero) {
            player.animationPlayer.Play(CLIMB);
        } else {
            player.animationPlayer.Pause();
        }

        if (player.IsOnFloor()) {
            player.IsOnStairs = false; // Reset stairs state when on floor
            EmitSignal(State.SignalName.Transitioned, this, IDLE);
        } else if (Input.IsActionJustPressed(INPUT_JUMP)) {
            player.IsOnStairs = false; // Reset stairs state when on floor
            EmitSignal(State.SignalName.Transitioned, this, JUMP);
        } else if (!player.IsOnStairs) {
            EmitSignal(State.SignalName.Transitioned, this, FALL);
        }
    }
}
