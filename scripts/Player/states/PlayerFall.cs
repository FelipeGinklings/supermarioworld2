using Godot;

public partial class PlayerFall : PlayerState {
    public override void Enter() {
        player.animationPlayer.Play(FALL);
    }

    public void HaveHitSomething(Area2D area) {
        GD.Print($"Player: HaveHitSomething - Hit area: {area.Name} from parent: {area.GetParent().Name}");

        // Check if we hit a Koopa
        var koopa = area.GetParent() as CharacterBody2D;
        if (koopa != null && koopa.Name == "Koopa") {
            GD.Print("Player stomped on Koopa!");
            // You can add stomp logic here
        }
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